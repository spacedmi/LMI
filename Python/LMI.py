import json
import os
import sympy as sm
from lmi_sdp import LMI_PD, LMI_ND
from cvxopt import solvers
from lmi_sdp import to_cvxopt
import numpy as np

script_dir = os.path.dirname(__file__)
rel_path = "fields.json"
abs_file_path = os.path.join(script_dir, rel_path)

with open(abs_file_path) as fields_file:    
    fields = json.load(fields_file)

def GetBlockMatrix(A, B, C, D, dim):
	M = sm.zeros(dim, dim)

	for i in xrange(0, dim / 2, 1):
		for j in xrange(0, dim / 2, 1):
			M[i, j] = A[i, j]

	for i in xrange(0, dim / 2, 1):
		for j in xrange(0, dim / 2, 1):
			M[i, dim / 2 + j] = B[i, j]

	for i in xrange(0, dim / 2, 1):
		for j in xrange(0, dim / 2, 1):
			M[ dim / 2 + i, j] = C[i, j]

	for i in xrange(0, dim / 2, 1):
		for j in xrange(0, dim / 2, 1):
			M[ dim / 2 + i, dim / 2 + j] = D[i, j]
	return M;

N = 2
A = sm.Matrix([[-1, 0], [0,  -2]])

s = 0
for i in xrange(0, N + 1, 1):
    s = s + i

x = [sm.symbols('x' + str(i)) for i in xrange(0, s, 1)]
Iks = sm.zeros(N, N)

k = 0;
for i in xrange(0, N, 1):
    for j in xrange(i, N, 1):
        Iks[i, j] = x[k]
        Iks[j, i] = x[k]
        k += 1

lmi_list = []
for field in fields:
	if (field['Name'] == 0):
		mu = -field["Mu"]
		lmi_matrix = A * Iks +Iks * A.transpose() + 2 * mu * Iks;
		lmi = LMI_ND(lmi_matrix)
		lmi_list.append(lmi)
	elif (field['Name'] == 1):
		r = field["R"]	
		q = field["Q"]
		lmi_matrix = GetBlockMatrix(-r * Iks, q * Iks + A * Iks, q * Iks + Iks * A.transpose(), -r * Iks, 2 * N)
		lmi = LMI_ND(lmi_matrix)
		lmi_list.append(lmi)
	elif (field['Name'] == 2):
		nu = field["Nu"]
		lmi_matrix = GetBlockMatrix(-2 * nu * Iks, A * Iks - Iks * A.transpose(), -A * Iks + Iks * A.transpose() , -2 * nu * Iks, 2 * N);
		lmi = LMI_ND(lmi_matrix)
		lmi_list.append(lmi)
	elif (field['Name'] == 3):
		fi = 3.14 * field["Angle"] / 360.0
		lmi_matrix = GetBlockMatrix(
			(A * Iks + Iks * A.transpose()) * sm.sin(fi), (A * Iks - Iks * A.transpose()) * sm.cos(fi),
			(-A * Iks + Iks * A.transpose()) * sm.cos(fi), (A * Iks + Iks * A.transpose()) * sm.sin(fi), 2 * N)		
		lmi = LMI_ND(lmi_matrix)
		lmi_list.append(lmi)
	elif (field['Name'] == 4):
		mu1 = -field["Mu1"]
		mu2 = field["Mu2"]
		lmi_matrix = GetBlockMatrix(
			A * Iks + Iks * A.transpose() + 2 * mu1 * Iks, sm.zeros(N, N), 
			sm.zeros(N, N), -A * Iks - Iks * A.transpose() - 2 * mu2 * Iks, 2 * N)
		lmi = LMI_ND(lmi_matrix)
		lmi_list.append(lmi)

min_obj = x[0] + x[1]
solvers.options['show_progress'] = False
c, Gs, hs = to_cvxopt(min_obj, lmi_list, x)

sol = solvers.sdp(c, Gs = Gs, hs = hs)

k = 0
for i in xrange(0, N, 1):
    for j in xrange(i, N, 1):
        Iks[i, j] = '%.2f' % float(sol['x'][k])
        Iks[j, i] = '%.2f' % float(sol['x'][k])
        k += 1

print(np.matrix(Iks.tolist()))
if sum(sol['x']) > 0.001:
	print('True')
else:	
	print('False')
