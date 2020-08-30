import numpy as np
from matplotlib import pyplot as plt

x= [-20, -16, -12, -8, -3.5, -2, 5, 12, 18, 20, 24, 30]
y= [0.23, 0.2, 0.1, 0.025, 0.01, 0.01, 0.03, 0.06, 0.12, 0.15, 0.32, 0.435]

#近似式の係数
res5=np.polyfit(x, y, 5)
# res2=np.polyfit(x, y, 2)
# res3=np.polyfit(x, y, 3)
#近似式の計算
y5 = np.poly1d(res5)(x) #5次
# y2 = np.poly1d(res2)(x) #2次
# y3 = np.poly1d(res3)(x) #3次

# #グラフ表示
# plt.scatter(x, y, label='元データ')
# plt.plot(x, y5, label='5次')
# # plt.plot(x, y2, label='2次')
# # plt.plot(x, y3, label='3次')
# plt.legend()
# plt.show()
print(res5)

#f(x)=ax^5+bx^4+cx^3+dx^2+ex+f 
#print(res??)で係数を表示
#-2.23e-3= -0.0023