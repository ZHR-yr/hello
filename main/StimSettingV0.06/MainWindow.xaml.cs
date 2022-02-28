using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Data;

namespace StimSettingV0._06
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window  //Window可以创建、配置显示和管理生存期窗口和对话框
    {
        public MainWindow()
        {
            InitializeComponent();

            circle1.Height = UserConstDefine.markerCircleHeigh;        //刺激点圈的高度，和红色菱形的高度
            circle1.Width = UserConstDefine.markerCircleWidth;         //刺激点圈的宽度，和红色菱形的宽度
            Panel.SetZIndex(circle1, 2);                     //设置circle1的层次  后面数越大 越在上面
            createMovePosMarker();
            myPolyline.Opacity = 0.5;                          //轨迹折线的透明度
            myPolyline.StrokeThickness = 3;                   //轨迹折线的厚度
            FormStimSetting.Show();                             //先打开参数设置页面
            FormStimSetting.Hide();                              //再把参数设置页面隐藏
            formStimRecord.saveCanves = saveCanvas;            //数据页面的保存
        }

        #region     当前移动点的标记

        Polygon presentPosMarker = new Polygon();//当前位置    
        void createMovePosMarker()//绘制当前位置点的标记。一个方块加一个箭头组成
        {
            double Lx = UserConstDefine.markerCircleWidth / 2;    //红色菱形的高度
            double Ly = UserConstDefine.markerCircleHeigh / 2;      //红色菱形的宽度
            double Lh = 20;         //红色箭头的总长度
            double arrorH = 10;     //红色箭头前段小箭头的长度
            double arrorW = 4;      //红色箭头前段小箭头的宽度
            presentPosMarker.Stroke = Brushes.Red;       //红色箭头的颜色为红色


            presentPosMarker.Points.Add(new Point(0, 0));//0        //0红色箭头的起点
            presentPosMarker.Points.Add(new Point(Lx, 0));//1
            presentPosMarker.Points.Add(new Point(0, Ly));//2
            presentPosMarker.Points.Add(new Point(-Lx, 0));//3
            presentPosMarker.Points.Add(new Point(0, -Ly));//4         //红色菱形的坐标连在一起
            presentPosMarker.Points.Add(new Point(Lx, 0));//5

            presentPosMarker.Points.Add(new Point(Lx + Lh, 0));//6          //012345678910是按顺序相连的
            presentPosMarker.Points.Add(new Point(Lx + Lh, arrorW));//7
            presentPosMarker.Points.Add(new Point(Lx + Lh + arrorH, 0));//8
            presentPosMarker.Points.Add(new Point(Lx + Lh, -arrorW));//9       //红色箭头的坐标连在一起
            presentPosMarker.Points.Add(new Point(Lx + Lh, 0));//10

            if (presentPosMarker.Parent == null)                //如果没有任何操作（没开始之前），就在采集界面显示菱形和箭头
                Canvas1.Children.Add(presentPosMarker);
            Canvas.SetZIndex(presentPosMarker, 1);        //前面一个事件元素，后面的参数越大越在上面

            Canvas.SetLeft(presentPosMarker, 100);
            Canvas.SetTop(presentPosMarker, 200);    //菱形框和箭头的初始位置
        }
        #endregion
        

        #region   绘制刺激发生点蓝色箭头的刺激标记
        private Polygon drawPg(double angle)                //绘制刺激发生点蓝色箭头的刺激标记
        {
            double handleHeigh = 20;              //刺激之后蓝色箭头底部的长度
            double arrorHeigh = 10;               //蓝色箭头顶端的长度
            double handleWidth = 2;               //蓝色箭头底部的宽度
            double arrorWidth = handleWidth + 3;  //蓝色箭头顶端的宽度
            double LowWidth = UserConstDefine.markerCircleWidth / 2;
            Polygon p = new Polygon();
            Point p1 = new Point(-handleWidth, LowWidth);
            Point p2 = new Point(-handleWidth, handleHeigh);
            Point p3 = new Point(-arrorWidth, handleHeigh);
            Point p4 = new Point(0, handleHeigh + arrorHeigh);
            Point p5 = new Point(arrorWidth, handleHeigh);
            Point p6 = new Point(handleWidth, handleHeigh);
            Point p7 = new Point(handleWidth, LowWidth);
            Point p8 = new Point(-handleWidth, LowWidth);
            p.Points.Add(p1); p.Points.Add(p2); p.Points.Add(p3); p.Points.Add(p4);
            p.Points.Add(p5); p.Points.Add(p6); p.Points.Add(p7); p.Points.Add(p8);
            p.Stroke = Brushes.Blue;
            p.RenderTransform = new RotateTransform(angle + presentAngle);   
            return p;
        }
        #endregion


        #region   绘制刺激之后圆形点下面的绿色三角标记
        void drawArrorInCir(ref Polygon L)     //绘制刺激之后圆形点下面的小三角正向标记
        {
            double arrorHeigh = UserConstDefine.markerCircleHeigh / 2;
            double arrorWidth = UserConstDefine.markerCircleWidth / 8;
            double arrorConstant = 4;

            //Polyline L = new Polyline();
            L.Stroke = Brushes.Green;
            L.StrokeThickness = 1;
            L.Points.Add(new Point(-arrorWidth, 0));
            L.Points.Add(new Point(arrorWidth, 0));
            L.Points.Add(new Point(0, arrorHeigh));
            L.Points.Add(new Point(0, -(arrorHeigh + arrorWidth- arrorConstant)));
            L.Points.Add(new Point(0, arrorHeigh));
            L.Points.Add(new Point(-arrorWidth, 0));

            L.RenderTransform = new RotateTransform(presentAngle - 90);
        }
        #endregion


        #region   绘制刺激标记并复制到textBlockStim
        private void drawStimMark(int stimId, Point p, STIM_PAR_DEFINE par)//在当前的坐标点绘制一个刺激数据标记  drawStimMark
        {
            //--------------绘圈---------------------------------------------
            Ellipse cir = new Ellipse();
            cir.Height = UserConstDefine.markerCircleHeigh;
            cir.Width = UserConstDefine.markerCircleWidth;
            cir.Stroke = Brushes.Black;
            cir.Fill = new SolidColorBrush(Colors.White);
            //用指定的 System.Windows.Media.Color 初始化 System.Windows.Media.SolidColorBrush 类的新实例
            cir.Opacity = 0.5;
            cir.MouseEnter += Cir_MouseEnter;   //红色圈属性  //MouseEnter 在鼠标指针进入此元素的边界时发生
            cir.Cursor = Cursors.Cross;   //Cursor获取或设置在鼠标指针位于此元素上时显示的光标   Cross十字光标    鼠标在刺激点时，光标为十字
            Canvas1.Children.Add(cir);     //把刺激点的圆圈添加到canvas的子元素中 显示出来 不添加就不显示
            Canvas.SetZIndex(cir, 3);    //刺激后的圆圈显示在两个方向箭头的上面

            Canvas.SetLeft(cir, p.X - cir.Width / 2);   //把圆圈设置在刺激点的中心位置
            Canvas.SetTop(cir, p.Y - cir.Height / 2);   //XY坐标起初是以圆圈边缘为准



            string s = "";
            s += string.Format("ID:   {0}\n", stimId);
            s += string.Format("time:{0,10:N0}mS\n", par.time);   //10代表前面有多少位  N后面是几 就保留几位小数
            s += string.Format("Pos : {0,6}, {1,6}\n", p.X, p.Y);  //0,1是后面数的索引，6代表前面有多少位
            s += string.Format("Angle:{0,-10:f2}'\n", presentAngle);
            s += string.Format("Velc: {0,-10:f2} Pt/s\n", veloc);    //f后面是几就保留几位小数  负代表反向开始数

            s += string.Format("Amp:{0} mV\n", par.amp);
            s += string.Format("N:  {0}\n", par.N);
            s += string.Format("T:  {0} mS\n", par.T);
            s += string.Format("Tw: {0} mS\n", par.Tw);
            cir.ToolTip = s;                     //圈的提示
            textBlockStim.Text = s;           //在textBlockStim上显示刺激参数

            //--------绘刺激点箭头和方向----------------------------------------------------
            double angle = -90;
            if (par.direction == DIRECTION_DEFINE.DIRECTION_LEFT) angle = 180;
            else if (par.direction == DIRECTION_DEFINE.DIRECTION_RIGHT) angle = 0;  
            else if (par.direction == DIRECTION_DEFINE.DIRECTION_LEFT_FORWARD) angle =  -135;  
            else if (par.direction == DIRECTION_DEFINE.DIRECTION_RIGHT_FORWARD) angle = -45;  

            //蓝色刺激箭头
            Polygon pg = drawPg(angle);
            Canvas1.Children.Add(pg);                   //把蓝色箭头添加到canvas1的子元素
            Canvas.SetLeft(pg, p.X);                 //蓝色箭头跟随者刺激点的角度移动
            Canvas.SetTop(pg, p.Y);

            //绿色箭头
            Polygon pline = new Polygon();
            drawArrorInCir(ref pline);     
            Canvas1.Children.Add(pline);            //同理 把正向黑色小三角标显示出来  跟随移动
            Canvas.SetLeft(pline, p.X);     //以交叉中心点为准
            Canvas.SetTop(pline, p.Y);
        }

        private void Cir_MouseEnter(object sender, MouseEventArgs e)
        {
            Ellipse c = (Ellipse)sender;
            //UIElement c = (UIElement)sender;

            Point p = new Point();
            p.X = Canvas.GetLeft(c);      //GetLeft返回指定元素的left坐标  //控制红色刺激点的左右
            p.Y = Canvas.GetTop(c);                                      //控制红色刺激点的上下
            textBlockStim.Text = c.ToolTip.ToString();
            //ToolTip工具提示对象  注释之后鼠标再放上去不再提示该点的刺激信息

            if (circle1.Parent == null)     //设置鼠标再刺激点上  刺激点为红色  不放为白色
                Canvas1.Children.Add(circle1);  //circle1表示红色的圈
            Canvas.SetLeft(circle1, p.X);       //控制红色刺激点的左右
            Canvas.SetTop(circle1, p.Y);         //控制红色刺激点的上下
        }
        #endregion


        #region   鼠标在Canvas移动事件
        private void Canvas_MouseMove(object sender, MouseEventArgs e)   //记录路线  MouseMove移动时就发生
                                                                         //有点不太懂 还要在研究
        {
            if (checkBoxLine.IsChecked == true)//绘格线    //如果按下了选中绘制参考线按钮
            {
                Point p2 = e.GetPosition(this.Canvas1);  //GetPosition返回鼠标指针相对于指定元素的位置
                int k = GridLine.Points.Count;//Points获取或设置一个集合，其中包含 System.Windows.Shapes.Polyline 的顶点
                if (k < 1)                   //k获取网格线点的数量
                    return;
                GridLine.Points[k - 1] = p2;   //不太懂
                return;
            }

            if (isSysHasTouchPanel) return;//有触控板时，不响应mose事件    return返回整个大函数 无参数时返回null

            if (checkBoxStartRecord.IsChecked != true)//记录路线    checkBox选中开始记录
                return;
            Point p = e.GetPosition(this.Canvas1);
            solvePostionMoving(p);
        }


        void solvePostionMoving(Point p)     //分析当前移动点
        {
            int t = System.Environment.TickCount - startTime;   //TickCount获取系统启动后的毫秒数
            solveNewPostion(p, t);
            addOneRecord();   //常规移动时记录的数据点，仅含位置
        }
        #endregion


        #region  触控板上触摸移动
        private bool isSysHasTouchPanel = false;//标记系统有无触控板
        private void Canvas1_TouchMove(object sender, TouchEventArgs e)   //手指触摸移动
        {
            isSysHasTouchPanel = true;
            if (checkBoxStartRecord.IsChecked != true)//记录路线
                return;

            int k = e.TouchDevice.Id;   // TouchDevice  获取生成事件的触摸设备

            TouchPoint p = e.GetTouchPoint(this.Canvas1);  //GetTouchPoint返回触摸设备相对于指定元素的当前位置
                                                           //Rect rc = p.Bounds;
            Point p1 = p.Position;
            solvePostionMoving(p1);
        }
        #endregion
        

        #region   对新位置进行解析 

        public Point presentPoint = new Point(0, 0);//记录前动物所在点的坐标为（0，0）

        int MaxLen = 2;
        double showLength = 20;
        double oldX = 0, oldY = 0;
        int oldt = 0;
        double presentAngle = 0;
        double veloc = 0;//当前点的运动速度

        Polygon PL = new Polygon();   //蓝色运动方向的线
        private void solveNewPostion(Point p, int time)//测试对像当前移动到新位置，按坐标对新位置的数据进行解析
        {
            if (Math.Abs(p.X - oldX) < 10 && Math.Abs(p.Y - oldY) < 10)      //  &&  且
                return;                                 //移动过小不分析  return直接结束该函数执行下一函数
            double dx = p.X - oldX;
            double dy = p.Y - oldY;        //点（Point）  1 in（英寸）= 2.54cm = 25.4 mm = 72pt（点） = 6pc（派卡）
            double dt = time - oldt;
            //为什么<10，比例是多少，这个还得继续研究,还是找不清楚以什么为基本单位
            if (dt == 0)
                return;
            veloc = Math.Sqrt(dx * dx + dy * dy) / dt * 1000;//当前点与前一点的位置算出速度  dt的单位是毫秒，换算成秒*1000
            oldt = time;

            double angle = Math.Atan(dy / dx) * 180 / Math.PI;    //别纠结，这整个式子的结果与咱们传统数学想法一致
            //π弧度＝180°    1弧度＝180°/ π （≈57.3°）
            //arctan(-A) = -arctan(A)
            //Atan = arctanx   PI = 3.1415926
            //角度= （弧度*180）/PI                        Math.Atan(dy / dx)返回的是弧度值，系统函数自定义好的，不能用传统数学理论
            //所有三角函数操作的是弧度   不是角度！
            if (dx < 0) angle += 180;           //左边框是X轴的0点，越往右越大
            if (angle < 0) angle += 360;        //上边框是Y轴的0点，越往下越大
            presentAngle = angle;

            //蓝色方向线
            PL.Points.Clear();
            PL.Points.Add(new Point(0, 0));
            PL.Points.Add(new Point(10 * dx, 10 * dy));
            if (PL.Parent == null)
            {
                PL.Stroke = Brushes.Blue;
                PL.StrokeThickness = 3;
                Canvas1.Children.Add(PL);
            }
            Canvas.SetLeft(PL, p.X);
            Canvas.SetTop(PL, p.Y);

            //当前位置点标记 显示、位置、角度
            if (presentPosMarker.Parent == null)            //父元素为空，当前标记作为子元素添加到Canvas1中。
                Canvas1.Children.Add(presentPosMarker);     //已经开始采集了，就会显示当前菱形加箭头的标记

            Canvas.SetLeft(presentPosMarker, p.X);  //跟随X坐标左右动       //SetLeft(UIElement element, double length);
                                                    //element要写入属性值的元素。length设置指定元素的 Left 坐标。
            Canvas.SetTop(presentPosMarker, p.Y);   //跟随Y坐标上下动
            
            presentPosMarker.RenderTransform = new RotateTransform(presentAngle);//RotateTransform该实例具有指定的顺时针旋转角度（以度为单位）。旋转中心位于原点(0,0)
                                                                                 //控制箭头和菱形的方向，注释掉之后  只朝一个方向，不再变化      // angle:顺时针旋转角度，以度为单位。                                    

            textBlockVA.Text = string.Format("V={0,10:f2}Pt/s\n", veloc);  //Format(String, Object)	 将字符串中的一个或多个格式项替换为指定对象的字符串表示形式。
                                                                           //0是索引后面第一个值     f代表保留几位小数    10代表前面有多大距离 0是没有距离
            textBlockVA.Text += string.Format("angle={0,10:f2} '\n", angle);

            presentPoint = p;
            oldX = p.X; oldY = p.Y;
            myPolyline.Points.Add(p);
        }
        #endregion


        #region   测试时使用   鼠标点击事件  点击才会发生
        private void Canvas1_MouseDown(object sender, MouseButtonEventArgs e)//没有连接单片机时，只用于程序研发过程中的测试
        {                                            // 鼠标按下时就发生MouseDown

            //绘考格线
            if (checkBoxLine.IsChecked == true)//绘格线
            {
                if (e.RightButton == MouseButtonState.Pressed)      //右键退出  RightButton获取鼠标右键的当前状态
                                                                    //Released = 0 该按钮处于释放状态。
                                                                    //  Pressed = 1   该按钮处于按下状态。
                {
                    checkBoxLine.IsChecked = false;
                    GridLine.Points.RemoveAt(GridLine.Points.Count - 1); //RemoveAt移除指定索引处的point
                    return;                         
                }
                Point p1 = e.GetPosition(this.Canvas1);//取出坐标
                if (GridLine.Points.Count == 0)    //GridLine参考线  
                    GridLine.Points.Add(p1);        //点为0时  把第一个点添加
                GridLine.Points.Add(p1);     //把每一个点添加，从第一个点开始     //鼠标左键点击一下绘制

                if (GridLine.Parent == null)
                    Canvas1.Children.Add(GridLine);    //显示出来

                return;
            }
            if (isSysHasTouchPanel) return;//有触控板时，不响应mose点击事件

            if (checkBoxStartRecord.IsChecked != true)
                return;
            if (e.RightButton == MouseButtonState.Pressed)//右键退出
            {
                checkBoxStartRecord.IsChecked = false;
                return;
            }
            Point p = e.GetPosition(this.Canvas1);//取出坐标

            STIM_PAR_DEFINE sp = new STIM_PAR_DEFINE();
            sp = FormStimSetting.usersDefinedPar;
            if (e.ChangedButton == MouseButton.Left)  //MouseButton定义用于指定鼠标设备上的按钮的值
                                                      //鼠标左按钮Left = 0   鼠标中键Middle = 1  鼠标右按钮Right = 2
                sp.direction = DIRECTION_DEFINE.DIRECTION_LEFT;
            else if (e.ChangedButton == MouseButton.Right)
                sp.direction = DIRECTION_DEFINE.DIRECTION_RIGHT;
            else if (e.ChangedButton == MouseButton.Middle)
                sp.direction = DIRECTION_DEFINE.DIRECTION_LEFT_FORWARD;        

            sp.amp = 10;   //测试时电压为10  
            sp.time = System.Environment.TickCount - startTime;
            int k = addOneRecord(sp);// 只记录刺激发生时的数据点    只有电压和方向
            drawStimMark(k, p, sp);//坐标点绘制成线，返回值是当前坐标记录点的序号
        }
        #endregion
        



        #region  清空记录按钮
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            clearAllMark();
        }

        private void clearAllMark()//清除所有当前绘制的图标和线条
        {
            myPolyline.Points.Clear();

            int i = Canvas1.Children.Count;
            for (int k = i - 1; k >= 0; k--)
            {
                UIElement c = Canvas1.Children[k];   //UIElement 布局时即便空间不够也不会故意去将超出边界的部分切掉
                if (c.GetType().Name == "Ellipse")   //GetType获取当前实例的准确运行时类型
                {
                    Canvas1.Children.Remove(c);
                }
                else if (c.GetType().Name == "Polygon")
                {
                    Canvas1.Children.Remove(c);
                }
            }
        }
        #endregion

        #region   选中开始记录控件
        public FormStimRecord formStimRecord = new FormStimRecord();
        public DataTable recordDataTable = null;//记录各种动作的数据表，这里不是实体

        int startTime = 0;//记录开始的时间
        private void checkBoxStartRecord_Checked(object sender, RoutedEventArgs e)
        {
            if (formStimRecord.recordTable.Rows.Count > 0)
            {
                if (MessageBox.Show("当前数据覆盖么？") != MessageBoxResult.OK)
                    return;    //MessageBox显示消息框   MessageBoxResult指定用户单击哪个按钮
            }
            //选中，开始记录
            clearAllMark();
            isSysHasTouchPanel = false;
            formStimRecord.recordTable.Rows.Clear();
            startTime = System.Environment.TickCount;
        }
        #endregion

        #region  选中绘制参考线控件
        Polyline GridLine = new Polyline();//绘制格线
        private void checkBoxLine_Checked(object sender, RoutedEventArgs e)
        {
            GridLine.Points.Clear();
            GridLine.Stroke = Brushes.BurlyWood;
            GridLine.Opacity = 0.5;
            GridLine.StrokeThickness = 20;
        }


        #endregion

        #region   回放按钮
        private void buttonVideo_Click(object sender, RoutedEventArgs e)
        {
            clearAllMark();
            checkBoxStartRecord.IsChecked = false;

            System.Threading.Thread anotherThread = new System.Threading.Thread(new ThreadStart(() =>    //Thread创建并控制线程
                                                                                                         //new Thread(t)和new Thread(new ThreadStart(t))在产生的效果上没有什么区别。                                                                                           //ThreadStart表示在Thread上执行的方法
            {                                                                                            //lambda表达式定义  不执行
                Point p = new Point();
                int timeStartRePlay = System.Environment.TickCount;
                int t = 0;
                foreach (DataRow r in formStimRecord.recordTable.Rows)
                {

                    p = new Point((double)(float)r["posX"], (double)(float)r["posY"]);//取出当前记录的坐标值;
                    STIM_PAR_DEFINE par = phraseStimPar(r);
                    /**/
                    t = (int)r["time"];
                    if (r["TYPE"].ToString() != DIRECTION_DEFINE.NONE_STIM.ToString())
                    {
                        presentAngle = (double)(float)r["Angle"];
                        veloc = (double)(float)r["Veloc"];
                        Canvas1.Dispatcher.Invoke((Action)(() => { drawStimMark((int)r["ID"], p, par); }));//激活
                        Thread.Sleep(1);                                 //Action封装一个方法，该方法不具有参数且不返回值
                    }                                                   //Invoke(Action) 在与 Action 关联的线程上同步执行指定的 Dispatcher。
                                                                        // (Action)(() => { drawStimMark((int)r["ID"], p, par); }) 这是一组
                                                                        // 利用Dispacther.Invoke调用更新drawStimMark
                    Canvas1.Dispatcher.Invoke((Action)(() => { solveNewPostion(p, t); }));

                    while (System.Environment.TickCount - timeStartRePlay < t)
                        Thread.Sleep(10);

                    //Thread.Sleep(10);
                }
                this.Dispatcher.Invoke((Action)(() => { textBlockStim.Text += "回放完成\n"; }));

            }));

            anotherThread.SetApartmentState(ApartmentState.STA);
            anotherThread.IsBackground = true;//.Priority = ThreadPriority.Lowest;
            anotherThread.Start();     //线程开始执行
        }


        STIM_PAR_DEFINE phraseStimPar(DataRow r)   //从数据行中解析出参数结构体
        {
            STIM_PAR_DEFINE par = new STIM_PAR_DEFINE();
            par.direction = (DIRECTION_DEFINE)Enum.Parse(typeof(DIRECTION_DEFINE), (string)r["TYPE"]);  //把刺激类型转换成数字
            par.amp = (int)r["amp"];    //Parse 将一个或多个枚举常数的名称或数字值得字符串表示转换成等效的枚举对象。
            par.T = (int)r["T"];        //=是后面赋值给前面
            par.Tw = (int)r["Tw"];
            par.N = (int)r["N"];
            par.time = (int)r["time"];

            return par;
        }
        #endregion

         


        #region   数据文件按钮
        private void buttonDataFile_Click(object sender, RoutedEventArgs e)
        {
            formStimRecord.Show();
        }
        #endregion


        #region  记录数据页面的保存
        //记录数据页面的保存
        void saveCanvas(string path)              //保存
        {
            util.SaveCanvas(this, this.Canvas1, 96, path);    
        }
        #endregion


        #region  电信号参数设定按钮
        FormStimParSetting FormStimSetting = new FormStimParSetting();
        private void buttonDataSetting_Click(object sender, RoutedEventArgs e)
        {
            FormStimSetting.Show();
        }

        #endregion


        #region   四个刺激按钮

        bool hasSolved = false;
        private void buttonStim_Click(object sender, RoutedEventArgs e)//各种刺激发生
        {               //buttonStim_Click左右 左前 右前按钮

            //if (isSysHasTouchPanel) return;
            if (hasSolved)
            {
                hasSolved = false;                
                return;
            }
            Button bt = (Button)sender;
            string s = bt.Content.ToString();
            exeStimButtons(s);
            hasSolved = false;
        }

        void exeStimButtons(string btnTxt)   
        {
            FormStimSetting.solveCmdBtn(btnTxt, startTime);
            int k = addOneRecord(FormStimSetting.usersDefinedPar);//真实刺激发生时记录的数据点
                                                                  //frmStimSetting.usersDefinedPar.time = System.Environment.TickCount - startTime;
            drawStimMark(k, presentPoint, FormStimSetting.usersDefinedPar);//
        }


        /// <summary>
        /// 数据表中记录当前点，返回值是当前坐标记录点的序号
        /// </summary>
        /// <param name="stimPar"></param>
        /// <returns></returns>
        public int addOneRecord(STIM_PAR_DEFINE stimPar = new STIM_PAR_DEFINE()) //常规移动时记录的数据点，仅含位置
        {
            DataRow r = formStimRecord.recordTable.NewRow();   //DataRow表示DataTable中的一行数据
                                                               //创建与该表具有相同架构的新 System.Data.DataRow。
                                                               //返回结果:System.Data.DataRow，其架构与 System.Data.DataTable 的架构相同
            if (stimPar.amp == 0)     //不刺激的时候电压为0，只有刺激了才有电压
                r["TYPE"] = DIRECTION_DEFINE.NONE_STIM.ToString();   //ToString()将NONE_STIM转换为其等效的字符串表示出来。
            else
                r["TYPE"] = stimPar.direction.ToString();        //将具体的刺激方向展现出来
            r["time"] = System.Environment.TickCount - startTime;//stimPar.time; TickCount获取系统电脑启动之后的毫秒数
            r["posX"] = presentPoint.X;              //当前位置的X坐标 赋值给r["time"] 
            r["posY"] = presentPoint.Y;              //当前位置的Y坐标 赋值给r["posY"]
            r["amp"] = stimPar.amp;                  //获取当前点的电压  赋值给r["amp"]      
            r["T"] = stimPar.T;
            r["Tw"] = stimPar.Tw;
            r["N"] = stimPar.N;
            r["Angle"] = presentAngle;
            r["Veloc"] = veloc;

            formStimRecord.recordTable.Rows.Add(r);      //把r数组中获取的一行行数据添加到记录表中

            return formStimRecord.recordTable.Rows.Count - 1;  //Count获取该集合中 System.Data.DataRow 对象的总数。  -1 是因为从0开始（ID）
                                                               //一次执行一行  反复循环
        }


        private void buttonStims_TouchDown(object sender, TouchEventArgs e)//各种刺激发生
        {                                         //buttonStims_TouchDown刺激按钮触摸按下 
            Button bt = (Button)sender;
            string s = bt.Content.ToString();
            exeStimButtons(s);
            hasSolved = true;
        }
        #endregion

    }
}
