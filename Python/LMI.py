import json
from sympy import symbols, Matrix, sin, cos, zeros, ones
from lmi_sdp import LMI_PD, LMI_ND
from cvxopt import solvers
from lmi_sdp import to_cvxopt
import numpy as np

# with open('fields.json') as fields_file:    
#     fields = json.load(fields_file)

# for field in fields:
# 	print(field['Name'])

N = 3
A = Matrix([[-21, -11, 0], [-11, 10, 8], [0, 8, 5]])
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

x = [symbols('x' + str(i)) for i in xrange(0, s, 1)]
Iks = zeros(N, N)

k = 0;
for i in xrange(0, N, 1):
    for j in xrange(i, N, 1):
        Iks[i, j] = x[k]
        Iks[j, i] = x[k]
        k += 1

print(r *Iks * r *Iks - ((q *Iks + A *Iks) * (q *Iks +Iks * A.transpose())))
lmi_1 = LMI_ND(A *Iks +Iks * A.transpose() + 2 * mu *Iks, 0)
lmi_2 = LMI_ND(-r *Iks, 0)
lmi_3 = LMI_PD(r *Iks * r *Iks - ((q *Iks + A *Iks) * (q *Iks +Iks * A.transpose())), 0)
# lmi_4 = LMI_ND(-2 * nu *Iks, 0)
# lmi_5 = LMI_PD(4 * nu * nu *Iks *Iks - (A *Iks -Iks * A.transpose()) * (-A *Iks +Iks * A.transpose()), 0)
# lmi_6 = LMI_ND((A *Iks +Iks * A.transpose()) * sin(fi), 0)
# lmi_7 = LMI_PD((A *Iks +Iks * A.transpose()) * sin(fi) * (A *Iks +Iks * A.transpose()) * sin(fi) - ((A *Iks -Iks * A.transpose()) * cos(fi) * (A *Iks -Iks * A.transpose()) * cos(fi)), 0)
# lmi_8 = LMI_ND(A *Iks +Iks * A.transpose() + 2 * mu1 *Iks, 0)
# lmi_9 = LMI_PD((A *Iks +Iks * A.transpose() + 2 * mu1 *Iks) * (-A *Iks -Iks * A.transpose() - 2 * mu2 *Iks), 0)

min_obj = x[1]
solvers.options['show_progress'] = False
c, Gs, hs = to_cvxopt(min_obj, [lmi_1, lmi_2, lmi_3], x)

sol = solvers.sdp(c, Gs = Gs, hs = hs)
print(sol['x'])