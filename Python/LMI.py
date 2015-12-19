import json
import sympy as sm
from lmi_sdp import LMI_PD, LMI_ND
from cvxopt import solvers
from lmi_sdp import to_cvxopt
import numpy as np

# with open('fields.json') as fields_file:    
#     fields = json.load(fields_file)

# for field in fields:
# 	print(field['Name'])

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

N = 3
A = sm.Matrix([[-21, -11, 0], [-11, 10, 8], [0, 8, 5]])
mu = 3.0
r = 5.0
q = 10.0
nu = 7.0
fi = 1.5
mu1 = 1.0
mu2 = 7.0

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

print(GetBlockMatrix(-r * Iks, q * Iks + A * Iks, q * Iks + Iks * A.transpose(), -r * Iks, 2 * N))
lmi_1_matrix = A * Iks +Iks * A.transpose() + 2 * mu * Iks;
lmi_2_matrix = GetBlockMatrix(-r * Iks, q * Iks + A * Iks, q * Iks + Iks * A.transpose(), -r * Iks, 2 * N)
lmi_3_matrix = GetBlockMatrix(-2 * nu * Iks, A * Iks - Iks * A.transpose(), -A * Iks + Iks * A.transpose() , -2 * nu * Iks, 2 * N);
lmi_4_matrix = GetBlockMatrix((A * Iks + Iks * A.transpose()) * sm.sin(fi), (A * Iks - Iks * A.transpose()) * sm.cos(fi),
	(A * Iks - Iks * A.transpose()) * sm.cos(fi), (A * Iks + Iks * A.transpose()) * sm.sin(fi), 2 * N);
lmi_5_matrix = GetBlockMatrix(A * Iks + Iks * A.transpose() + 2 * mu1 * Iks, sm.zeros(N, N), 
	sm.zeros(N, N), -A * Iks - Iks * A.transpose() - 2 * mu2 * Iks, 2 * N);

lmi_1 = LMI_ND(lmi_1_matrix, sm.zeros(N, N))
lmi_2 = LMI_ND(lmi_2_matrix, sm.zeros(2 * N, 2 * N))
lmi_3 = LMI_ND(lmi_3_matrix, sm.zeros(2 * N, 2 * N))
# lmi_4 = LMI_ND(lmi_4_matrix, sm.zeros(2 * N, 2 * N))
lmi_5 = LMI_ND(lmi_5_matrix, sm.zeros(2 * N, 2 * N))
# lmi_3 = LMI_PD(r * Iks * r * Iks - ((q * Iks + A * Iks) * (q * Iks + Iks * A.transpose())), 0)
# lmi_4 = LMI_ND(-2 * nu * Iks, 0)
# lmi_5 = LMI_PD(4 * nu * nu * Iks * Iks - (A * Iks -Iks * A.transpose()) * (-A * Iks +Iks * A.transpose()), 0)
# lmi_6 = LMI_ND((A * Iks +Iks * A.transpose()) * sm.sin(fi), 0)
# lmi_7 = LMI_PD((A * Iks +Iks * A.transpose()) * sm.sin(fi) * (A * Iks +Iks * A.transpose()) * sm.sin(fi) - ((A * Iks -Iks * A.transpose()) * sm.cos(fi) * (A * Iks -Iks * A.transpose()) * sm.cos(fi)), 0)
# lmi_8 = LMI_ND(A * Iks +Iks * A.transpose() + 2 * mu1 * Iks, 0)
# lmi_9 = LMI_PD((A * Iks +Iks * A.transpose() + 2 * mu1 * Iks) * (-A * Iks -Iks * A.transpose() - 2 * mu2 * Iks), 0)

min_obj = x[0]
solvers.options['show_progress'] = False
c, Gs, hs = to_cvxopt(min_obj, [lmi_1, lmi_2, lmi_3, lmi_5], x)

sol = solvers.sdp(c, Gs = Gs, hs = hs)
print(sol['x'])