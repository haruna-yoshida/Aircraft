import numpy as np
from matplotlib import pyplot as plt

x= [-20,-16,-12,-10,-4,2,10,18,20,24,30]
y= [-0.55,-0.75,-0.75,-0.52,0,0.5,1.2,1.65,1.65,1.2,0.9]

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
plt.plot(x, y5, label='5次')
# # plt.plot(x, y2, label='2次')
# # plt.plot(x, y3, label='3次')
plt.legend()
plt.show()
print(res5)

#f(x)=ax^5+bx^4+cx^3+dx^2+ex+f 
#print(res??)で係数を表示
#-2.23e-3= -0.0023