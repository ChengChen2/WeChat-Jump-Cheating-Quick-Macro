//-------------------------- 
// 作者：KalsasCaesar. 
// 描述：微信跳一跳自动脚本
//--------------------------

// 找到黑色棋子的位置坐标
Do
Delay 2000
// 初始化所有变量
pX = 0
pY = 0
tempX = 0
tempY = 0
intX = 0
intY = 0
upX = 0
upY = 0
downX = 0
downY = 0
midX = 0
midY = 0
finalX = 0
finalY = 0
distance = 0
presstime = 0
Do
FindColor 679,270,1240,783,"623938",pX,pY
If pX > 0 And pY > 0 Then 
	Exit Do
End If
Loop
Delay 200

// 如果棋子在屏幕左半边，计算距离
If pX < 960 Then
	//最远点初始化
	tempX = 1241
	tempY = pY - (tempX - pX) / 1.732
	
	//沿线判定(X轴向下30度)
	BackGroundColor = GetPixelColor(tempX, tempY) //得到第一个沿线最远背景点颜色值
	Do
	//在小范围内看是否能找到相近颜色(模糊对比)
	FindColorEx tempX-2,tempY,tempX,tempY+2,BackGroundColor,0,0.8,intX,intY 
	If intX > 0 And intY > 0 Then //如果能找到相近颜色则确认沿线的下一点
		tempX = tempX - 1
		tempY = pY - (tempX - pX) / 1.732
	Else 
 		upX = tempX  //此时找到了下一个小方块平面的上边沿一点的坐标
 		upY = tempY
 		SurfaceColor = GetPixelColor(upX, upY+2) //记录下下一个小方块平面上的颜色(且像素点微调偏移)
		Exit Do
	End If
	Loop
	Delay 200
	
	//计算下一个方块上边沿那点与棋子间直线的中点坐标，该点的颜色一般与下一个方块表面颜色不同
	midX = pX + (upX - pX) / 2
	midY = upY + (pY - upY) / 2
	Delay 200
	tempX = midX
	tempY = midY
	Do
	FindColorEx tempX,tempY-2,tempX+2,tempY,SurfaceColor,0,1.0,intX,intY
	If intX > 0 And intY > 0 Then  //如果找到与方块表面相同颜色说明是下一个方块同一直线上下边沿一点
		downX = intX  //记录下边沿该点的坐标值 
		downY = intY
		Exit Do
	Else 
		tempX = tempX + 1
		tempY = tempY - (1 / 1.732)
	End If
	Loop
	Delay 200
	
	//计算下一个方块沿线中心点坐标
	finalX = downX + (upX - downX) / 2 
	finalY = upY + (downY - upY) / 2
	distance = (pY - finalY) * 2  //计算棋子到下一个方块中心点的距离
	
//如果棋子在屏幕右半边，计算距离 
Else  
	//最远点初始化
	tempX = 679
	tempY = pY - (pX - tempX) / 1.732
	
	//沿线判定(X轴向下30度)
	BackGroundColor = GetPixelColor(tempX, tempY) //得到第一个沿线最远背景点颜色值
	Do
	//在小范围内看是否能找到相近颜色(模糊对比)
	FindColorEx tempX,tempY,tempX+2,tempY+2,BackGroundColor,0,0.8,intX,intY 
	If intX > 0 And intY > 0 Then //如果能找到相近颜色则确认沿线的下一点
		tempX = tempX + 1
		tempY = pY - (pX - tempX) / 1.732
	Else 
 		upX = tempX  //此时找到了下一个小方块平面的上边沿一点的坐标
 		upY = tempY
 		SurfaceColor = GetPixelColor(upX, upY+2) //记录下下一个小方块平面上的颜色(且像素点微调偏移)
		Exit Do
	End If
	Loop
	Delay 200
	
	//计算下一个方块上边沿那点与棋子间直线的中点坐标，该点的颜色一般与下一个方块表面颜色不同
	midX = upX + (pX - upX) / 2
	midY = upY + (pY - upY) / 2
	Delay 200
	tempX = midX
	tempY = midY
	Do
	FindColorEx tempX-2,tempY-2,tempX,tempY,SurfaceColor,0,1.0,intX,intY
	If intX > 0 And intY > 0 Then  //如果找到与方块表面相同颜色说明是下一个方块同一直线上下边沿一点
		downX = intX  //记录下边沿该点的坐标值 
		downY = intY
		Exit Do
	Else 
		tempX = tempX - 1
		tempY = tempY - (1 / 1.732)
	End If
	Loop
	Delay 200
	
	//计算下一个方块沿线中心点坐标
	finalX = upX + (downX - upX) / 2 
	finalY = upY + (downY - upY) / 2
	distance = (pY - finalY) * 2  //计算棋子到下一个方块中心点的距离
End If

// 控制鼠标按压一定时长
presstime = distance * 2.6642  //计算鼠标按压时间(时间系数2.6042)
MoveTo 722, 910//将鼠标移动至屏幕上一个不相关的点
Delay 200
LeftDown 1
Delay presstime
LeftUp 1
Delay 200
Loop
