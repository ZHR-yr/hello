using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace StimSettingV0._06
{
    #region   创建数据、方向、波形的结构体
    public struct STIM_PAR_DEFINE  //创建一个刺激参数的结构体   只是定义没有具体的数据
    {                               //在声明结构体时，不允许使用实例属性和字段初始化语句
        public int T;//正弦的周期或高电平持 续时间  ms
        public int N;//一组脉冲的个数
        public int Tw;//脉冲重复周期
        public int amp;//幅值 mV
        public int fai;//相位 度
        public WAVE_SHAPE waveShape;//波形
        public DIRECTION_DEFINE direction;

        public int time;//刺激发生的时间 ms
    }
    public enum DIRECTION_DEFINE   //创建一个方向的枚举  常量
    {
        DIRECTION_UNKNOW = 0,
        DIRECTION_LEFT = 1,
        DIRECTION_RIGHT = 2,
        DIRECTION_LEFT_FORWARD = 3,
        DIRECTION_RIGHT_FORWARD = 4,
        NONE_STIM = 5,
    }
    public enum WAVE_SHAPE   //创建一个波形的枚举  常量
    {
        SIN = 0,
        RECTANGLE = 1,//rectangle矩形
    }
    #endregion

    public partial class FormStimParSetting : Form
    {
        public FormStimParSetting()
        {
            InitializeComponent();
            initPort();    //初始化端口配置
        }

        DataTable parTable = new DataTable();   //各种具体刺激参数设置页面表格
        DataTable drawTable = new DataTable();//绘图用的表格
        DataTable parTableLeft = new DataTable();//左 控制参数
        DataTable parTableRight = new DataTable();//右 控制参数
        DataTable parTableLeftForward = new DataTable();//左前 控制参数
        DataTable parTableRightForward = new DataTable();//左前 控制参数

        #region  窗体加载事件
        //load窗口加载事件   打开参数设定按钮时  就加载load事件
        private void FormStimParSetting_Load(object sender, EventArgs e)
        {       
            tableInit();   //加载参数设置表列标题，绘制波形的列标题  及列格式
            parInit();     //把表格的内容和波形展现出来

            foreach (Control c in this.Controls)//Controls获取包含在控件内的控件集合
            {

                foreach (Control c1 in c.Controls)
                {
                    foreach (Control c2 in c1.Controls)
                    {
                        c2.KeyPress += FormStimParSetting_KeyPress;//KeyPress（按键）在控件有焦点的情况下按下键时发生
                    }
                    c1.KeyPress += FormStimParSetting_KeyPress;
                }

                c.KeyPress += FormStimParSetting_KeyPress;
            }

            dataGridViewLeftchujiao.MouseWheel += DataGridView1_MouseWheel;
            dataGridViewRightchujiao.MouseWheel += DataGridView1_MouseWheel;
            dataGridViewLeftweixu.MouseWheel += DataGridView1_MouseWheel;
            dataGridViewRightweixu.MouseWheel += DataGridView1_MouseWheel;
        }

        private void FormStimParSetting_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {

            DataGridView dv = (DataGridView)sender;
            if (dv.SelectedCells.Count != 1)  //获取用户选择单元格的数量   只能选择一个单元格
                return;
            if (dv.SelectedCells[0].ColumnIndex != 2)  //获取用户选择单元格的列索引     修改参数的列必须是第三列 
                return;
            int val = int.Parse(dv.SelectedCells[0].Value.ToString());  //将选择的参数转化成整数
            int delta = e.Delta;
            string name = dv.Rows[dv.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            if (name == "Amp")
                delta = delta / 120 * 50;
            else if (name == "Fai")
                delta = delta / 120 * 10;
            else
                delta = delta / 120;
            dv.SelectedCells[0].Value = val + delta;
        }

        #endregion    //这地方的keypress还有疑问


        #region 绘制参数设置表列的标题，绘制波形表列的标题 ，以及格式
        //绘制参数设置表列的标题，绘制波形表列的标题，以及格式
        public void tableInit()
        {
            /////绘制各个参数列的标题和格式
            DataColumn column = new DataColumn();

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//编号  0 byte  //DataType获取或设置存储在列中的数据类型
            column.AllowDBNull = false; //获取或设置一个值，该值指示对于属于该表的行，此列是否允许空值
            column.Caption = "parID";   //获取或者设置列的标题
            column.ColumnName = "ID";   //列的名称
            column.ReadOnly = true;   //一旦向表中添加了行，列是否允许更改
            column.AutoIncrement = true;   //添加到该表中的新行，列是否将列的值自动递增
            parTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");//编号  0 byte
            column.AllowDBNull = false;
            column.Caption = "参数名";
            column.ColumnName = "参数名";
            column.DefaultValue = 0;   //创建新行时，获取或设置列的默认值
                                       //column.ReadOnly = false;
            parTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");//编号  0 byte
            column.AllowDBNull = false;
            column.Caption = "参数值";
            column.ColumnName = "参数值";
            column.DefaultValue = 0;
            //column.ReadOnly = false;
            parTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");//编号  0 byte
            column.AllowDBNull = false;
            column.Caption = "单位";
            column.ColumnName = "单位";
            column.DefaultValue = 0;
            //column.ReadOnly = false;
            parTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");//编号  0 byte
            column.AllowDBNull = false;
            column.Caption = "说明";
            column.ColumnName = "说明";
            column.DefaultValue = 0;
            //column.ReadOnly = false;
            parTable.Columns.Add(column);

            ////////////////////////////////      ---绘图表格的初始化
            drawTable.Columns.Clear();

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//编号  0 byte
            column.AllowDBNull = false;
            column.Caption = "ID";
            column.ColumnName = "ID";
            //column.DefaultValue = 0;
            column.AutoIncrement = true;
            //column.ReadOnly = false;
            drawTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//时间 ms
            column.AllowDBNull = false;
            column.Caption = "time";
            column.ColumnName = "time";
            column.DefaultValue = 0;
            //column.ReadOnly = false;
            drawTable.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//电压 mV
            column.AllowDBNull = false;
            column.Caption = "voltage";
            column.ColumnName = "voltage";
            column.DefaultValue = 0;
            //column.ReadOnly = false;
            drawTable.Columns.Add(column);
        }
        #endregion


        #region  添加初始刺激数据到各个位置的表格内
        //添加初始刺激数据到各个位置的表格内
        void parInit()
        {
            parTable.Rows.Clear();        //具体参数设置列表的第一行  信号周期T
            DataRow r = parTable.NewRow();

            r["参数名"] = "T";
            r["参数值"] = "10";
            r["单位"] = "ms";
            r["说明"] = "单脉冲周期";
            parTable.Rows.Add(r);

            r = parTable.NewRow();//具体参数设置列表的第二行  一组脉冲个数N
            r["参数名"] = "N";
            r["参数值"] = "25";
            r["单位"] = "-";
            r["说明"] = "一组脉冲个数";
            parTable.Rows.Add(r);

            r = parTable.NewRow();  //具体参数设置列表的第三行  脉冲重复周期TW
            r["参数名"] = "Tw";
            r["参数值"] = "20";
            r["单位"] = "mS";
            r["说明"] = "脉冲重复周期";
            parTable.Rows.Add(r);

            r = parTable.NewRow();//具体参数设置列表的第四行  电压Amp
            r["参数名"] = "Amp";
            r["参数值"] = "1500";
            r["单位"] = "mV";
            r["说明"] = "输出电压幅值";
            parTable.Rows.Add(r);

            //r = parTable.NewRow();   //具体参数设置列表的第五行  相位Fai
            //r["参数名"] = "φ";
            //r["参数值"] = "-150";
            //r["单位"] = "度";
            //r["说明"] = "输出电压相位                      -";
            //parTable.Rows.Add(r);

            //四个通道（左触角、右触角、左尾须、右尾须），四张表格（此表并已经是页面中的表，而是储存在内部的表），对应了四个View 
            parTableLeft = parTable.Copy();
            parTableRight = parTable.Copy();
            parTableLeftForward = parTable.Copy();
            parTableRightForward = parTable.Copy();

            parTableLeft.TableName = "parTableLeft";            //4个通道表的名称
            parTableRight.TableName = "parTableRight";
            parTableLeftForward.TableName = "parTableLeftForward";
            parTableRightForward.TableName = "parTableRightForward";

            dataGridViewLeftchujiao.Columns.Clear();  //Columns获取包含在控件中所有列的集合
            dataGridViewRightchujiao.Columns.Clear(); //把4个表格的列全部清理
            dataGridViewLeftweixu.Columns.Clear();
            dataGridViewRightweixu.Columns.Clear();

            //DataSource获取或设置数据源DataGridView显示数据
            dataGridViewLeftchujiao.DataSource = parTableLeft; //parTableLeft内部表不显示   dataGridView外部显示的表
            dataGridViewRightchujiao.DataSource = parTableRight;
            dataGridViewLeftweixu.DataSource = parTableLeftForward;
            dataGridViewRightweixu.DataSource = parTableRightForward;

            //修改数据之后，更新数据表中的说明  并对修改后的数据重新生成波形
            updateTables(parTableLeft);
            updateTables(parTableRight);
            updateTables(parTableLeftForward);
            updateTables(parTableRightForward);

            //Update使控件重绘其工作区的无效区域   内部表设置完毕之后  显示的表格也要更新一下
            dataGridViewLeftchujiao.Update();
            dataGridViewRightchujiao.Update();
            dataGridViewLeftweixu.Update();
            dataGridViewRightweixu.Update();
        }
        #endregion


        #region   保存打开按钮

        //保存按钮
        private void toolStripButtonSaveFile_Click(object sender, EventArgs e)
        {
            saveParFile();
        }

        SaveFileDialog sf = new SaveFileDialog();
        void saveParFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = ("par files(*.par)|*.par|All files (*.*)|*.*");

            if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            //获取保存的路径
            //toolStripStatusLabel3.Text = saveFileDialog1.FileName;

            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            sw.Write(getTableStr(parTableLeft));
            sw.Write(getTableStr(parTableRight));
            sw.Write(getTableStr(parTableLeftForward));
            sw.Write(getTableStr(parTableRightForward));
            sw.Close();
        }

        string getTableStr(DataTable dt)
        {
            string s = "";

            string name = dt.TableName;
            foreach (DataRow r in dt.Rows)
            {
                s += name + ",";
                for (int i = 0; i < 5; i++)
                {
                    s += r[i].ToString();
                    s += ",";
                }
                s += "\r\n";
            }

            return s;

        }


        private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
        {
            openParFile();
        }

        void openParFile()
        {
            parTableLeft.Rows.Clear();
            parTableRightForward.Rows.Clear();
            parTableRight.Rows.Clear();
            parTableLeftForward.Rows.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "par files (*.par)|*.par|All files (*.*)|*.*";
            //saveFileDialog1.FilterIndex = 2;
            //saveFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //toolStripStatusLabel3.Text = openFileDialog1.FileName;
            StreamReader mysr = new StreamReader(openFileDialog1.FileName);
            string s = ""; string[] aryline;
            DataTable dt = parTable;
            DataRow r = parTable.NewRow();
            while ((s = mysr.ReadLine()) != null)  //ReadLine()从当前流中读取一行字符并将数据作为字符串返回
            {
                //s = mysr.ReadLine();
                //s = s.ToLower();
                s = s.Replace(" ", "");  //Replace返回一个新字符串，其中当前实例中出现的所有指定字符串都替换为另一个指定的字符串。
                aryline = s.Split(new char[] { ',' });   //Split返回的字符串数组包含此实例中的子字符串

                switch (aryline[0].ToLower())  //ToLower返回此字符串转换为小写形式的副本
                {
                    case "partableleft":
                        dt = parTableLeft;
                        break;

                    case "partableright":
                        dt = parTableRight;
                        break;

                    case "partableleftforward":
                        dt = parTableLeftForward;
                        break;
                    case "partablerightforward":
                        dt = parTableRightForward;
                        break;
                    default:
                        MessageBox.Show("没这表");
                        break;
                }
                r = dt.NewRow();
                r[0] = aryline[1];
                r[1] = aryline[2];
                r[2] = aryline[3];
                r[3] = aryline[4];
                r[4] = aryline[5];
                dt.Rows.Add(r);
            }

        }
        #endregion


        #region  数据表发生变化之后，更新数据表，并绘制新波形
        //表格数据改变事件
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)   //如果行索引小于0，则程序不执行
            {
                return;
            }

            updateTables();
            return;

        }

        //修改数据之后，更新数据表中的说明  并对修改后的数据重新生成波形
        void updateTables(DataTable b = null)
        {
            DataTable ttb = null;   //null没有创建内存空间，""是创建了内存空间

            if (b == null)
            {
                string tabName = "";
                tabName = tabControl1.SelectedTab.Text;  //获取当前位置表格的文本名称

                switch (tabName)
                {
                    case "左触角":
                        ttb = parTableLeft;
                        break;
                    case "右触角":
                        ttb = parTableRight;
                        break;
                    case "左尾须":
                        ttb = parTableLeftForward;
                        break;
                    case "右尾须":
                        ttb = parTableRightForward;
                        break;
                }
            }
            else
                ttb = b;

            if (ttb == null) return;

            STIM_PAR_DEFINE st = new STIM_PAR_DEFINE();

            //遍历当前数据表的行数组，并对修改的内容在说明中重新计算
            foreach (DataRow r in ttb.Rows)
            {
                if ((string)r[1] == "T")
                {
                    int Tval = int.Parse((string)r[2]);
                    st.T = Tval;
                    r[4] = string.Format("信号周期<=> {0,4:f}Hz", 1.0f / (float)Tval * 1000.0f);
                }   //Format将指定字符串的一个或多个格式项替换为指定对象的字符串表示形式 
                else if ((string)r[1] == "Tw")
                {
                    int TWval = int.Parse((string)r[2]);
                    st.Tw = TWval;
                    if (st.Tw <= st.T)
                    {
                        MessageBox.Show("脉冲重复周期不应小于脉冲信号周期 ！！");
                        st.Tw = 2 * st.T;
                        r[2] = st.Tw;  //小于的话自动调整为信号周期的2倍
                    }
                    r[4] = string.Format("脉冲重复周期<=>{0,4:f}Hz;  D={1,4:f}%", 1.0f / (float)TWval * 1000.0f, (float)st.T / (float)st.Tw * 100.0f);
                    //Tw参数  说明一栏内容 
                }
            }
            drawStimWave(ttb);
        }
        #endregion


        #region   绘制波形图
        //绘制波形
        private void drawStimWave(DataTable tb)   //参数是该位置的整个数据表
        {
            DataTable t = drawTable.Clone();   //绘制波形图用的表格

            //遍历数据表的行数组，把数组中的各个参数取出来
            int amp = 0, T = 0, Tw = 0, N = 0;
            foreach (DataRow r in tb.Rows)
            {
                if ((string)r[1] == "T")   //如果遍历的第二个参数为T，就把T的第三个参数值赋值给T
                    T = int.Parse(r[2].ToString());
                else if ((string)r[1] == "Tw")
                    Tw = int.Parse(r[2].ToString());
                else if ((string)r[1] == "Amp")
                    amp = int.Parse(r[2].ToString());
                else if ((string)r[1] == "N")
                    N = int.Parse(r[2].ToString());
            }


            int time = 0;
            DataRow rt = null;
            //描点法，将波形的点放到drawTable中
            for (int i = 0; i < N; i++)          //drawTable  0列是ID  1列是time  2列是voltage
            {                                   //通过点连接出来的波形  X是time  Y是voltage
                rt = t.NewRow(); rt[1] = time; rt[2] = 0; t.Rows.Add(rt);           //0  第一个点
                rt = t.NewRow(); rt[1] = time + Tw - T; rt[2] = 0; t.Rows.Add(rt);  //1

                rt = t.NewRow(); rt[1] = time + Tw - T; rt[2] = amp; t.Rows.Add(rt);  //2
                rt = t.NewRow(); rt[1] = time + Tw; rt[2] = amp; t.Rows.Add(rt);      //3
                rt = t.NewRow(); rt[1] = time + Tw; rt[2] = 0; t.Rows.Add(rt);      //4
                time += Tw;
            }
            rt = t.NewRow(); rt[1] = 500; /*time + Tw*N;*/ rt[2] = 0; t.Rows.Add(rt);      //4   最后一个点（长横杠）

            //将集合中数据点的XY值绑定到指定数据源的指定列的数据
            //将time和voltage与横纵坐标XY绑定起来   x值索取到t表下的time列
            //t.DefaultView    X列的数据源   time  X列的名称
            //Series[0]   从0开始的索引
            chartWave.Series[0].Points.DataBindXY(t.DefaultView, "time", t.DefaultView, "voltage");
        }


        private void checkBoxWave_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion




        #region    四个刺激按钮事件
        //四个按钮事件
        private void buttonLeftForward_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            solveCmdBtn(b.Text);     //获取点击按钮的文本并进行相应动作
        }

        public STIM_PAR_DEFINE usersDefinedPar; //实例化一个结构体
        //分析按下的按钮，获取按钮刺激方向、按下时间、刺激波形，并把刺激参数数据打包
        public void solveCmdBtn(string cmdBtnStr, int startTime = 0)
        {
            //string s = "";
            switch (cmdBtnStr)
            {
                case "左":
                    usersDefinedPar.direction = DIRECTION_DEFINE.DIRECTION_LEFT;
                    tabControl1.SelectedIndex = 0;  //设置当前选项卡页的索引

                    break;
                case "右":
                    usersDefinedPar.direction = DIRECTION_DEFINE.DIRECTION_RIGHT;
                    tabControl1.SelectedIndex = 1;

                    break;
                case "左前":
                    usersDefinedPar.direction = DIRECTION_DEFINE.DIRECTION_LEFT_FORWARD;
                    tabControl1.SelectedIndex = 2;

                    break;
                case "右前":
                    usersDefinedPar.direction = DIRECTION_DEFINE.DIRECTION_RIGHT_FORWARD;
                    tabControl1.SelectedIndex = 3;

                    break;

                default:
                    break;
            }

            /* s += "  ";
             s += System.DateTime.Now.ToString();
             toolStripStatusLabel4.Text = s;   //获取当前的时间和日期赋值给   底左5

             //根据用户选择波形
             if (checkBoxWave.Checked)
                 usersDefinedPar.waveShape = WAVE_SHAPE.RECTANGLE;   //矩形波
             else
                 usersDefinedPar.waveShape = WAVE_SHAPE.SIN;    //正弦波   */

            usersDefinedPar.time = System.Environment.TickCount - startTime;

            readPar();
            comCmdDownload();
        }
        #endregion


        #region 获取刺激表格中T、Tw、amp、fai、N数据   传参给绘制波形
        //按当前的动作，找到对应的表格，将表格中的数据打包到数据结构中作为参数，在下一步的工作中下行到下位机
        //获取刺激表格中T、Tw、amp、fai、N数据
        //通过获取的数据   传参给绘制波形
        private void readPar()
        {
            DataTable tb = new DataTable();
             
            switch (usersDefinedPar.direction)  //获取当前动作的方向  只有刺激了才有通信
            {
                case DIRECTION_DEFINE.DIRECTION_LEFT:
                    tb = parTableLeft;
                    break;
                case DIRECTION_DEFINE.DIRECTION_RIGHT:
                    tb = parTableRight;
                    break;
                case DIRECTION_DEFINE.DIRECTION_LEFT_FORWARD:
                    tb = parTableLeftForward;
                    break;
                case DIRECTION_DEFINE.DIRECTION_RIGHT_FORWARD:
                    tb = parTableRightForward;
                    break;
                default:
                    MessageBox.Show("未知的方向定义，已出错！");
                    break;
            }
            try
            {
                foreach (DataRow r in tb.Rows)
                {
                    string s = r["参数名"].ToString();  //一行一行的遍历  遍历到参数名的行就转换为字符串  只遍历数据
                    switch (s)              //[ID:data,参数名：string1，参数值：string2。。。]
                    {
                        case "T":
                            usersDefinedPar.T = int.Parse((string)r["参数值"]);
                            break;
                        case "N":
                            usersDefinedPar.N = int.Parse((string)r["参数值"]);
                            break;
                        // 						case "D":
                        // 							usersDefinedPar.D = int.Parse((string)r["参数值"]);
                        // 							break;
                        case "Tw":
                            usersDefinedPar.Tw = int.Parse((string)r["参数值"]);
                            break;
                        case "Amp":
                            usersDefinedPar.amp = int.Parse((string)r["参数值"]);
                            break;
                        case "Fai":
                            usersDefinedPar.fai = int.Parse((string)r["参数值"]);
                            break;
                        default:
                            MessageBox.Show("未定义的参数，找找看看，有没有错误");
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message + "数据解析出错，检查输入数据是否符合要求");
            }
            drawStimWave(tb);
        }
        #endregion


        #region   把刺激数据转换成字节数组，写入到缓存指令中   再传输给端口
        
        //将int型数据转换成字符数组的形式储存，索引从1开始
        void parInt32IntoByte(int dat, byte[] b, int startIndex)
        {
            byte[] tb = BitConverter.GetBytes(dat);   //BitConverter将基础数据类型与字节数组相互转换
                                        //将int型转换成byte[]       byte[]（字节数组
                                        //例dat=10  
                                        //把dat中的数据依次放入cmdBuffer中，索引从1开始
            for (int i = 0; i < 4; i++)
                b[startIndex + i] = tb[i];
        }

        /// <summary>
		/// 发送指定总长为totleLength,最后两个写节作为校验和
		/// </summary>
		/// <param name="b"></param>                      
		/// <param name="totleLength"></param>
		private void sendCmdStringFillSum(byte[] b, int totleLength)
        {
            int checkLeng = totleLength - 2;
            UInt16 sum = 0;
            for (int i = 0; i < checkLeng; i++)
                sum += b[i];
            byte[] tb = BitConverter.GetBytes(sum);
            b[checkLeng] = tb[0];               //b[30]
            b[checkLeng + 1] = tb[1];           //b[31]
        }


        //把刺激数据写入指令缓存字节数组中
        byte[] cmdBuffer = new byte[40];    //创建一个指令缓存字节数组
        void comCmdDownload()
        {
            if (serialPort1 == null)
                return;
            //端口没打开，就把端口打开
            if (!serialPort1.IsOpen)
                serialPort1.Open();

            cmdBuffer[0] = (byte)22;     //把22放进第一个索引空间

            //把各个数据依次放进字符数组中
            parInt32IntoByte(usersDefinedPar.T, cmdBuffer, 1);//[1-4]    
            parInt32IntoByte(usersDefinedPar.Tw, cmdBuffer, 5);//[5-8]
            parInt32IntoByte(usersDefinedPar.N, cmdBuffer, 9);//[9-12]
            parInt32IntoByte(usersDefinedPar.amp, cmdBuffer, 13);//[13-16]
            parInt32IntoByte(usersDefinedPar.fai, cmdBuffer, 17);//[17-20]
         

            sendCmdStringFillSum(cmdBuffer, 32);      //cmdBuffer[30]  cmdBuffer[31]
            //serialPort1.Close();
            serialPort1.Write(cmdBuffer, 0, 32);        //把字节数组写入端口  从0开始，总共32位
                                                        //Write(Byte[], Int32, Int32)  使用缓冲区中的数据将指定数量的字节写入串行端口。
                                                        //buffer Byte[]包含要写入端口的数据的字节数组。
                                                        //offset  Int32  buffer 参数中从零开始的字节偏移量，从此处开始将字节复制到端口
                                                        //count Int32 buffer 要写入的字节数。
        }
        #endregion


        #region  端口管理       

        int maxIndex = 1;//找出最大的那个串口号
        //寻找可用端口
        public int searchAvaliblePorts()   //返回值是索引
        {
            bool _available = false;

            //SerialPort串行端口资源   创建一个临时串口_tempPort
            SerialPort _tempPort;

            //获取当前计算机串行端口名的数组
            String[] Portname = SerialPort.GetPortNames();  //GetPortNames获取当前计算机的串行端口名称数组 
                                //com1  com2...

            int index = 0;
            foreach (string str in Portname)
            {
                bool portOpened = false;

                //3为指定开始索引，后面的参数是索引获取的长度
                string s = str.Substring(3, str.Length - 3);   //Substring检索子字符串。子字符串从指定的字符位置开始且具有指定的长度
                int k = int.Parse(s);
                if (k <= 2)
                    continue;
                if (k > maxIndex)
                    maxIndex = k;

                try
                {
                    _tempPort = new SerialPort(str);
                    if (_tempPort.IsOpen)
                    {
                        portOpened = true;
                    }
                    else
                    {
                        portOpened = false;
                        _tempPort.Open();
                    }
                    if (_tempPort.IsOpen)
                    {
                        _tempPort.Close();
                        _available = true;
                    }
                }
                catch (Exception ex)
                {

                    _available = false;
                }
                index++;
            }
            if (index < 4)
                MessageBox.Show("完全找出不合适的端口配置");

            return index;
        }


        string[] comPortNames = new string[40];
        void initPort()
        {
            if (searchAvaliblePorts() < 4)
            {
                serialPort1 = null;
                return;
            }
            for (int i = 0; i < 40; i++)
            {
                comPortNames[i] = "COM" + i.ToString();
            }
            if (serialPort1 == null)
            {
                serialPort1 = new SerialPort();
            }
            serialPort1.Close();
            //关了原有串口后才可设置新申请的串口
            serialPort1.BaudRate = 115200;   //BaudRate串口波特率
            serialPort1.Encoding = UTF8Encoding.UTF8;//Encoding串口传输前后文本转换的字节编码
            serialPort1.ReceivedBytesThreshold = 1;//获取或设置 DataReceived 事件发生前内部输入缓冲区中的字节数
            serialPort1.PortName = comPortNames[maxIndex - 2];//"COM5"; 10  14   18   //2   //获取或设置通信端口，包括但不限于所有可用的 COM 端口
            serialPort1.Open();
        }
        #endregion


        #region  关闭事件
        private void FormStimParSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        #endregion


        #region  接收端口数据，将它返回到richTextBox控件中
        //端口数据接收，将数据显示在richTextBox控件中
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //读取对象或缓冲区中，所有立即可用的字节
            string s = serialPort1.ReadExisting();  //ReadExisting读取当前所能读到的数据，以字符串的形式返回

            //将获取的字节追加到文本
            this.Invoke((EventHandler)delegate    //Invoke在拥有此控件的基础窗口句柄的线程上执行指定的委托    //C#中的委托可以理解为函数的包装。
                                //调用Invoke方法的原因是  避免出现线程冲突
            {
                //richTextBox.AppendText(s);
                //richTextBox.ScrollToCaret();

                //if (richTextBox.Text.Length > 20000)
                //    richTextBox.Text = "";
            });
        }





        #endregion
    }
}
