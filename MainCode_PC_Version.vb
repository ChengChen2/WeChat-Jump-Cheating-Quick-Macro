//-------------------------- 
// ���ߣ�KalsasCaesar. 
// ������΢����һ���Զ��ű�
//--------------------------

// �ҵ���ɫ���ӵ�λ������
Do
Delay 2000
// ��ʼ�����б���
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

// �����������Ļ���ߣ��������
If pX < 960 Then
	//��Զ���ʼ��
	tempX = 1241
	tempY = pY - (tempX - pX) / 1.732
	
	//�����ж�(X������30��)
	BackGroundColor = GetPixelColor(tempX, tempY) //�õ���һ��������Զ��������ɫֵ
	Do
	//��С��Χ�ڿ��Ƿ����ҵ������ɫ(ģ���Ա�)
	FindColorEx tempX-2,tempY,tempX,tempY+2,BackGroundColor,0,0.8,intX,intY 
	If intX > 0 And intY > 0 Then //������ҵ������ɫ��ȷ�����ߵ���һ��
		tempX = tempX - 1
		tempY = pY - (tempX - pX) / 1.732
	Else 
 		upX = tempX  //��ʱ�ҵ�����һ��С����ƽ����ϱ���һ�������
 		upY = tempY
 		SurfaceColor = GetPixelColor(upX, upY+2) //��¼����һ��С����ƽ���ϵ���ɫ(�����ص�΢��ƫ��)
		Exit Do
	End If
	Loop
	Delay 200
	
	//������һ�������ϱ����ǵ������Ӽ�ֱ�ߵ��е����꣬�õ����ɫһ������һ�����������ɫ��ͬ
	midX = pX + (upX - pX) / 2
	midY = upY + (pY - upY) / 2
	Delay 200
	tempX = midX
	tempY = midY
	Do
	FindColorEx tempX,tempY-2,tempX+2,tempY,SurfaceColor,0,1.0,intX,intY
	If intX > 0 And intY > 0 Then  //����ҵ��뷽�������ͬ��ɫ˵������һ������ͬһֱ�����±���һ��
		downX = intX  //��¼�±��ظõ������ֵ 
		downY = intY
		Exit Do
	Else 
		tempX = tempX + 1
		tempY = tempY - (1 / 1.732)
	End If
	Loop
	Delay 200
	
	//������һ�������������ĵ�����
	finalX = downX + (upX - downX) / 2 
	finalY = upY + (downY - upY) / 2
	distance = (pY - finalY) * 2  //�������ӵ���һ���������ĵ�ľ���
	
//�����������Ļ�Ұ�ߣ�������� 
Else  
	//��Զ���ʼ��
	tempX = 679
	tempY = pY - (pX - tempX) / 1.732
	
	//�����ж�(X������30��)
	BackGroundColor = GetPixelColor(tempX, tempY) //�õ���һ��������Զ��������ɫֵ
	Do
	//��С��Χ�ڿ��Ƿ����ҵ������ɫ(ģ���Ա�)
	FindColorEx tempX,tempY,tempX+2,tempY+2,BackGroundColor,0,0.8,intX,intY 
	If intX > 0 And intY > 0 Then //������ҵ������ɫ��ȷ�����ߵ���һ��
		tempX = tempX + 1
		tempY = pY - (pX - tempX) / 1.732
	Else 
 		upX = tempX  //��ʱ�ҵ�����һ��С����ƽ����ϱ���һ�������
 		upY = tempY
 		SurfaceColor = GetPixelColor(upX, upY+2) //��¼����һ��С����ƽ���ϵ���ɫ(�����ص�΢��ƫ��)
		Exit Do
	End If
	Loop
	Delay 200
	
	//������һ�������ϱ����ǵ������Ӽ�ֱ�ߵ��е����꣬�õ����ɫһ������һ�����������ɫ��ͬ
	midX = upX + (pX - upX) / 2
	midY = upY + (pY - upY) / 2
	Delay 200
	tempX = midX
	tempY = midY
	Do
	FindColorEx tempX-2,tempY-2,tempX,tempY,SurfaceColor,0,1.0,intX,intY
	If intX > 0 And intY > 0 Then  //����ҵ��뷽�������ͬ��ɫ˵������һ������ͬһֱ�����±���һ��
		downX = intX  //��¼�±��ظõ������ֵ 
		downY = intY
		Exit Do
	Else 
		tempX = tempX - 1
		tempY = tempY - (1 / 1.732)
	End If
	Loop
	Delay 200
	
	//������һ�������������ĵ�����
	finalX = upX + (downX - upX) / 2 
	finalY = upY + (downY - upY) / 2
	distance = (pY - finalY) * 2  //�������ӵ���һ���������ĵ�ľ���
End If

// ������갴ѹһ��ʱ��
presstime = distance * 2.6642  //������갴ѹʱ��(ʱ��ϵ��2.6042)
MoveTo 722, 910//������ƶ�����Ļ��һ������صĵ�
Delay 200
LeftDown 1
Delay presstime
LeftUp 1
Delay 200
Loop
