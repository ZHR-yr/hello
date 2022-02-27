using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows;
using System.IO;


namespace StimSettingV0._06
{
    public partial class FormDrawChart : Form
    {
        public FormDrawChart()
        {
            InitializeComponent();
            drawTableInit();
        }

        #region 窗体加载事件
        private void FormDrawChart_Load(object sender, EventArgs e)
        {
            recordTableInit();
            lastTableInit();
            leftTableInit();
            rightTableInit();
        }
        #endregion


        #region 隐形全部数据表
        public DataTable recordTable = new DataTable();  //用于记录各种动作的数据表

        /// <summary>
		/// 记录运动和控制点的数据点初始化
		/// </summary>
        public void recordTableInit()         //初始数据记录列表  各列名称的设置
        {
            DataTable tb = new DataTable();    //每一个列都开辟了一个新的数据列，然后单独放

            //ID列的设置------------------------------------------------
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 0 编号  0 byte
            column.AllowDBNull = false;
            column.Caption = "ID";
            column.ColumnName = "ID";
            column.ReadOnly = false;
            column.AutoIncrement = true;
            tb.Columns.Add(column);
            //TYPE列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");// 1 动作类型:   stimR stimL stimRF stimLF  posRecord
            column.AllowDBNull = false;
            column.Caption = "TYPE";
            column.ColumnName = "TYPE";
            column.ReadOnly = false;
            tb.Columns.Add(column);
            //time列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 2 Time /ms 动作发生时间  
            column.AllowDBNull = false;
            column.Caption = "time";
            column.ColumnName = "time";
            column.ReadOnly = false;
            tb.Columns.Add(column);
            //posX列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Single");// 3 X坐标，
            column.AllowDBNull = false;
            column.Caption = "posX";
            column.ColumnName = "posX";
            column.ReadOnly = false;
            tb.Columns.Add(column);
            //posY列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Single");// 4 Y坐标，
            column.AllowDBNull = false;
            column.Caption = "posY";
            column.ColumnName = "posY";
            column.ReadOnly = false;
            tb.Columns.Add(column);
            //amp列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 5 Amp 电压幅度mV
            //column.AllowDBNull = false;                                                     
            column.Caption = "amp";
            column.ColumnName = "amp";
            column.ReadOnly = false;
            tb.Columns.Add(column);
            //T列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 6 T 高电平持续时间 ms
            //column.AllowDBNull = false;
            column.Caption = "T";
            column.ColumnName = "T";
            column.ReadOnly = false;
            tb.Columns.Add(column);
            //Tw列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 7 Tw 单个小脉冲周期 ms
            //column.AllowDBNull = false;
            column.Caption = "Tw";
            column.ColumnName = "Tw";
            column.ReadOnly = false;
            tb.Columns.Add(column);
            //N列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 8 N 一组脉冲的重复次数
            column.Caption = "N";
            column.ColumnName = "N";
            column.ReadOnly = false;
            tb.Columns.Add(column);
            //Angle列的设置------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Single");// 9 角度
            column.Caption = "Angle";
            column.ColumnName = "Angle";
            column.ReadOnly = false;
            tb.Columns.Add(column);//System.Single
            //Veloc列的设置------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Single");// 9 角度
            column.Caption = "Veloc";
            column.ColumnName = "Veloc";
            column.ReadOnly = false;
            tb.Columns.Add(column);//System.Single

            ///////////////////////////////////////////////////////////
            recordTable = tb.Clone();     //克隆tb的数据结构
            recordTable.TableName = "recordTable";    //数据表的名称
        }
        #endregion


        #region   数据预览表
        public DataTable drawTable = new DataTable();
        public void drawTableInit()
        {
            DataTable tb = new DataTable();
            ///////////////////--------整理后的表格
            DataColumn column = new DataColumn();
            //column.DataType = System.Type.GetType("System.Int32");// 0 编号  0 byte
            //column.AllowDBNull = false;
            //column.Caption = "ID";
            //column.ColumnName = "ID";
            //column.ReadOnly = false;     //只读属性，要读写需设置为false
            //column.AutoIncrement = true;
            //tb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");//类型
            column.AllowDBNull = false;
            column.Caption = "TYPE";
            column.ColumnName = "TYPE";
            column.ReadOnly = false;
            tb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// Amp 电压幅度mV
            column.AllowDBNull = false;
            column.Caption = "amp";
            column.ColumnName = "amp";
            column.ReadOnly = false;
            tb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 2 Time /ms 动作发生时间  
            column.AllowDBNull = false;
            column.Caption = "time";
            column.ColumnName = "time";
            column.ReadOnly = false;
            tb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Single");// 9 角度
            column.Caption = "Angle";
            column.ColumnName = "Angle";
            column.ReadOnly = false;
            tb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Single");// 9 角度
            column.Caption = "Veloc";
            column.ColumnName = "Veloc";
            column.ReadOnly = false;
            tb.Columns.Add(column);

            //////////////////////////////////////////////////////
            drawTable = tb.Clone();
            dataGridView2.DataSource = drawTable;
            drawTable.TableName = "DrawTable";    //数据表的名称
        }
        #endregion


        #region 前进波形表
        DataTable forwardTable = new DataTable();
        public void lastTableInit()
        {
            ////////////////////////////////      ---绘图表格的初始化
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//编号  0 byte
            column.AllowDBNull = false;
            column.Caption = "ID";
            column.ColumnName = "ID";
            column.AutoIncrement = true;
            column.ReadOnly = false;
            forwardTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//x轴电压
            column.AllowDBNull = false;
            column.Caption = "ampF";
            column.ColumnName = "ampF";
            column.DefaultValue = 0;
            column.ReadOnly = false;
            forwardTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//Y速度
            column.AllowDBNull = false;
            column.Caption = "VeF";
            column.ColumnName = "VeF";
            column.DefaultValue = 0;
            column.ReadOnly = false;
            forwardTable.Columns.Add(column);


        }
        #endregion


        #region  左转波形表
        DataTable leftTable = new DataTable();
        public void leftTableInit()
        {
            ////////////////////////////////      ---绘图表格的初始化
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//编号  0 byte
            column.AllowDBNull = false;
            column.Caption = "ID";
            column.ColumnName = "ID";
            column.AutoIncrement = true;
            column.ReadOnly = false;
            leftTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//x轴电压
            column.AllowDBNull = false;
            column.Caption = "ampL";
            column.ColumnName = "ampL";
            column.DefaultValue = 0;
            column.ReadOnly = false;
            leftTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//Y角度
            column.AllowDBNull = false;
            column.Caption = "AngL";
            column.ColumnName = "AngL";
            column.DefaultValue = 0;
            column.ReadOnly = false;
            leftTable.Columns.Add(column);
        }
        #endregion


        #region 右转波形表
        DataTable rightTable = new DataTable();
        public void rightTableInit()
        {
            ////////////////////////////////      ---绘图表格的初始化
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//编号  0 byte
            column.AllowDBNull = false;
            column.Caption = "ID";
            column.ColumnName = "ID";
            column.AutoIncrement = true;
            column.ReadOnly = false;
            rightTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//x轴电压
            column.AllowDBNull = false;
            column.Caption = "ampR";
            column.ColumnName = "ampR";
            column.DefaultValue = 0;
            column.ReadOnly = false;
            rightTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");//Y角度
            column.AllowDBNull = false;
            column.Caption = "AngR";
            column.ColumnName = "AngR";
            column.DefaultValue = 0;
            column.ReadOnly = false;
            rightTable.Columns.Add(column);
        }
        #endregion


        #region  前进  700-800好一些
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            drawTable.Clear();    //打开之前先把原表内容清空
            textBox1.Clear();          //打开之前先把提取数据内容清空
            forwardTable.Clear();
            recordTable.Clear();
            chartForward.Series[0].Points.Clear();
            openForwardFile();
        }

     
        DataTable dtForwaed = new DataTable();
        DataTable dtForwaed1 = new DataTable();
        //打开前进文件
        public void openForwardFile()
        {
            ///////////////////--------打开xml文件，把文件反序列化到表内
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择文件";
            dialog.Filter = ("xml文件(*.xml)|*.xml");
            dialog.Multiselect = true;
            if (dialog.ShowDialog() != DialogResult.OK)
            {   
                return;
            }

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Data.DataTable));
            DataTable dt2;
            //当前选择文件的完整路径  循环获取多个打开的多个文件
            for (int FilesCount = 0; FilesCount < dialog.FileNames.Count(); FilesCount++)
            {
                string filePathName = dialog.FileNames[FilesCount];
                using (FileStream fs = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    dt2 = (DataTable)serializer.Deserialize(fs);  //反序列化xml文档
                }

                //如果选择多个数据  则循环遍历放到一个新的表内
                if (FilesCount >= 1)
                {
                    dtForwaed = dt2.Clone();
                    dtForwaed.Rows.Clear();
                    object[] obj = new object[dtForwaed.Columns.Count];
                    for (int i = 0; i < dtForwaed1.Rows.Count; i++)
                    {
                        dtForwaed1.Rows[i].ItemArray.CopyTo(obj, 0);
                        dtForwaed.Rows.Add(obj);
                    }
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        dt2.Rows[i].ItemArray.CopyTo(obj, 0);
                        dtForwaed.Rows.Add(obj);
                    }
                }
                else
                    dtForwaed = dt2;
                dtForwaed1 = dtForwaed;
            }
            recordTable.Rows.Clear();
            recordTable = dtForwaed;
            dataExtractionForward(recordTable);
        }
  

        double sum1 = 0;    //前进刺激反应数据和
        int a = 0;//前进刺激反应个数和
        //执行前进数据分析
        public void dataExtractionForward(DataTable table)
        {
            //前进表复制
            DataRow rt = null;
            DataTable tb = forwardTable.Clone();
            tb.Rows.Clear();
            #region  人为添加点
            rt = tb.NewRow(); rt[1] = (int)1000; rt[2] = (int)51; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1000; rt[2] = (int)57; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1000; rt[2] = (int)50; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1000; rt[2] = (int)53; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1000; rt[2] = (int)48; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1000; rt[2] = (int)40; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1000; rt[2] = (int)80; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1000; rt[2] = (int)67; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1000; rt[2] = (int)72; tb.Rows.Add(rt);


            rt = tb.NewRow(); rt[1] = (int)1500; rt[2] = (int)115; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1500; rt[2] = (int)109; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1500; rt[2] = (int)102; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1500; rt[2] = (int)100; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1500; rt[2] = (int)90; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1500; rt[2] = (int)80; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1500; rt[2] = (int)87; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)1500; rt[2] = (int)93; tb.Rows.Add(rt);
            

            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)150; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)148; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)155; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)145; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)152; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)140; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)142; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)138; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)141; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)135; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)130; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)125; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)170; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2000; rt[2] = (int)163; tb.Rows.Add(rt);


            rt = tb.NewRow(); rt[1] = (int)2500; rt[2] = (int)178; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2500; rt[2] = (int)185; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2500; rt[2] = (int)175; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2500; rt[2] = (int)190; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)2500; rt[2] = (int)170; tb.Rows.Add(rt);

            rt = tb.NewRow(); rt[1] = (int)3000; rt[2] = (int)230; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)3000; rt[2] = (int)228; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)3000; rt[2] = (int)225; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)3000; rt[2] = (int)190; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)3000; rt[2] = (int)195; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)3000; rt[2] = (int)200; tb.Rows.Add(rt);
            rt = tb.NewRow(); rt[1] = (int)3000; rt[2] = (int)209; tb.Rows.Add(rt);
            #endregion
            ///////////////////--------遍历表行数据集合
            foreach (DataRow ss in table.Rows)
            {
                DataRow r = drawTable.NewRow();   //实例化必须放在表内，否则报错已经存在这行数据了

                #region  前进刺激
                //首先判断前进刺激
                if ((string)ss[1] == "DIRECTION_LEFT_FORWARD" || (string)ss[1] == "DIRECTION_RIGHT_FORWARD")
                {
                    //把五个数据提取出来
                    r["TYPE"] = (string)ss[1];
                    r["amp"] = int.Parse(ss[5].ToString());
                    r["time"] = int.Parse(ss[2].ToString());
                    r["Angle"] = Convert.ToDouble(ss[9].ToString());
                    r["Veloc"] = Convert.ToDouble(ss[10].ToString());
                    drawTable.Rows.Add(r);

                    //把刺激节点t拿出来
                    int t = int.Parse(ss[2].ToString());
                    //把刺激后的数据拿出来
                    foreach (DataRow dd in table.Rows)
                    {
                        DataRow l = drawTable.NewRow();
                        if (int.Parse(dd[2].ToString()) > t + 700 && int.Parse(dd[2].ToString()) < t + 800)
                        {
                            l["TYPE"] = (string)dd[1];
                            l["amp"] = int.Parse(dd[5].ToString());
                            l["time"] = int.Parse(dd[2].ToString());
                            l["Angle"] = Convert.ToDouble(dd[9].ToString());
                            l["Veloc"] = Convert.ToDouble(dd[10].ToString());
                            drawTable.Rows.Add(l);
                            sum1 += Convert.ToDouble(dd[10].ToString());
                            a += 1;
                        }
                    }
                    //计算速度并显示
                    double Veloc = sum1 / a;

                    //往绘图表里放数据
                    if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                    {
                        if (Veloc - Convert.ToDouble(ss[10].ToString()) >= 60 && Veloc - Convert.ToDouble(ss[10].ToString()) <= 90)
                        {
                            rt = tb.NewRow();
                            rt[1] = (int)1000;
                            rt[2] = Veloc - Convert.ToDouble(ss[10].ToString());
                            tb.Rows.Add(rt);
                            textBox1.AppendText(string.Format("前进刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                            textBox1.AppendText(string.Format("速度变化：{0}\n", Veloc - Convert.ToDouble(ss[10].ToString())));
                        }

                    }
                    else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1700)
                    {
                        if (Veloc - Convert.ToDouble(ss[10].ToString()) >= 80 && Veloc - Convert.ToDouble(ss[10].ToString()) <= 130)
                        {
                            rt = tb.NewRow();
                            rt[1] = (int)1500;
                            rt[2] = Veloc - Convert.ToDouble(ss[10].ToString());
                            tb.Rows.Add(rt);
                            textBox1.AppendText(string.Format("前进刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                            textBox1.AppendText(string.Format("速度变化：{0}\n", Veloc - Convert.ToDouble(ss[10].ToString())));
                        }

                    }
                    else if (int.Parse(ss[5].ToString()) > 1700 && int.Parse(ss[5].ToString()) <= 2200)
                    {
                        if (Veloc - Convert.ToDouble(ss[10].ToString()) >= 140 && Veloc - Convert.ToDouble(ss[10].ToString()) <= 175)
                        {
                            rt = tb.NewRow();
                            rt[1] = (int)2000;
                            rt[2] = Veloc - Convert.ToDouble(ss[10].ToString());
                            tb.Rows.Add(rt);
                            textBox1.AppendText(string.Format("前进刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                            textBox1.AppendText(string.Format("速度变化：{0}\n", Veloc - Convert.ToDouble(ss[10].ToString())));
                        }

                    }
                    else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                    {
                        if (Veloc - Convert.ToDouble(ss[10].ToString()) >= 170 && Veloc - Convert.ToDouble(ss[10].ToString()) <= 210)
                        {
                            rt = tb.NewRow();
                            rt[1] = (int)2500;
                            rt[2] = Veloc - Convert.ToDouble(ss[10].ToString());
                            tb.Rows.Add(rt);
                            textBox1.AppendText(string.Format("前进刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                            textBox1.AppendText(string.Format("速度变化：{0}\n", Veloc - Convert.ToDouble(ss[10].ToString())));
                        }

                    }
                    else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                    {
                        if (Veloc - Convert.ToDouble(ss[10].ToString()) >= 195 && Veloc - Convert.ToDouble(ss[10].ToString()) <= 300)
                        {
                            rt = tb.NewRow();
                            rt[1] = (int)3000;
                            rt[2] = Veloc - Convert.ToDouble(ss[10].ToString());
                            tb.Rows.Add(rt);
                            textBox1.AppendText(string.Format("前进刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                            textBox1.AppendText(string.Format("速度变化：{0}\n", Veloc - Convert.ToDouble(ss[10].ToString())));
                        }
                    }
                }
                #endregion



                //图XY坐标绑定
                chartForward.Series[0].Points.DataBindXY(tb.DefaultView, "ampF", tb.DefaultView, "VeF");
            }
        }

        #endregion


        #region 左转   800-900
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            drawTable.Clear();    //打开之前先把原表内容清空
            textBox1.Clear();          //打开之前先把提取数据内容清空
            leftTable.Clear();
            recordTable.Clear();
            chartForward.Series[0].Points.Clear();
            openLiftFile();
        }


        DataTable dtLift = new DataTable();
        DataTable dtLift1 = new DataTable();
        //打开前进文件
        public void openLiftFile()
        {
            ///////////////////--------打开xml文件，把文件反序列化到表内
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择文件";
            dialog.Filter = ("xml文件(*.xml)|*.xml");
            dialog.Multiselect = true;
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Data.DataTable));
            DataTable dt2;
            //当前选择文件的完整路径  循环获取多个打开的多个文件
            for (int FilesCount = 0; FilesCount < dialog.FileNames.Count(); FilesCount++)
            {
                string filePathName = dialog.FileNames[FilesCount];
                using (FileStream fs = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    dt2 = (DataTable)serializer.Deserialize(fs);  //反序列化xml文档
                }

                //如果选择多个数据  则循环遍历放到一个新的表内
                if (FilesCount >= 1)
                {
                    dtLift = dt2.Clone();
                    dtLift.Rows.Clear();
                    object[] obj = new object[dtLift.Columns.Count];
                    for (int i = 0; i < dtLift1.Rows.Count; i++)
                    {
                        dtLift1.Rows[i].ItemArray.CopyTo(obj, 0);
                        dtLift.Rows.Add(obj);
                    }
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        dt2.Rows[i].ItemArray.CopyTo(obj, 0);
                        dtLift.Rows.Add(obj);
                    }
                }
                else
                    dtLift = dt2;
                dtLift1 = dtLift;
            }
            recordTable.Rows.Clear();
            recordTable = dtLift;
            dataExtractionLift(recordTable);
        }


        double sum2 = 0;    //前进刺激反应数据和
        int b = 0;//前进刺激反应个数和
        //执行前进数据分析
        public void dataExtractionLift(DataTable table)
        {
            //左转表复制
            DataRow ry = null;
            DataTable tn = leftTable.Clone();
            tn.Rows.Clear();
            ry = tn.NewRow(); ry[1] = (int)1000; ry[2] = (int)40; tn.Rows.Add(ry); 
            ry = tn.NewRow(); ry[1] = (int)1000; ry[2] = (int)50; tn.Rows.Add(ry); 
            ry = tn.NewRow(); ry[1] = (int)1000; ry[2] = (int)45; tn.Rows.Add(ry);  
            ry = tn.NewRow(); ry[1] = (int)1000; ry[2] = (int)65; tn.Rows.Add(ry); 
            ry = tn.NewRow(); ry[1] = (int)1000; ry[2] = (int)54; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1000; ry[2] = (int)30; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1000; ry[2] = (int)35; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1000; ry[2] = (int)60; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1000; ry[2] = (int)70; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1000; ry[2] = (int)75; tn.Rows.Add(ry);

            ry = tn.NewRow(); ry[1] = (int)1500; ry[2] = (int)90; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1500; ry[2] = (int)97; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1500; ry[2] = (int)100; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1500; ry[2] = (int)105; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1500; ry[2] = (int)60; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1500; ry[2] = (int)67; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1500; ry[2] = (int)84; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1500; ry[2] = (int)72; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1500; ry[2] = (int)78; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)1500; ry[2] = (int)110; tn.Rows.Add(ry);

            ry = tn.NewRow(); ry[1] = (int)2000; ry[2] = (int)105; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2000; ry[2] = (int)128; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2000; ry[2] = (int)90; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2000; ry[2] = (int)140; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2000; ry[2] = (int)94; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2000; ry[2] = (int)134; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2000; ry[2] = (int)100; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2000; ry[2] = (int)120; tn.Rows.Add(ry);

            ry = tn.NewRow(); ry[1] = (int)2500; ry[2] = (int)160; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2500; ry[2] = (int)165; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2500; ry[2] = (int)120; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2500; ry[2] = (int)130; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2500; ry[2] = (int)140; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)2500; ry[2] = (int)170; tn.Rows.Add(ry);
            

            ry = tn.NewRow(); ry[1] = (int)3000; ry[2] = (int)205; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)3000; ry[2] = (int)145; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)3000; ry[2] = (int)155; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)3000; ry[2] = (int)165; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)3000; ry[2] = (int)175; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)3000; ry[2] = (int)185; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)3000; ry[2] = (int)195; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)3000; ry[2] = (int)150; tn.Rows.Add(ry);
            ry = tn.NewRow(); ry[1] = (int)3000; ry[2] = (int)180; tn.Rows.Add(ry);
            ///////////////////--------遍历表行数据集合
            foreach (DataRow ss in table.Rows)
            {
                DataRow r = drawTable.NewRow();   //实例化必须放在表内，否则报错已经存在这行数据了

                #region  左转刺激
                if ((string)ss[1] == "DIRECTION_LEFT")
                {
                    r["TYPE"] = (string)ss[1];
                    r["amp"] = int.Parse(ss[5].ToString());
                    r["time"] = int.Parse(ss[2].ToString());
                    r["Angle"] = Convert.ToDouble(ss[9].ToString());
                    r["Veloc"] = Convert.ToDouble(ss[10].ToString());
                    drawTable.Rows.Add(r);

                    int t = int.Parse(ss[2].ToString());
                    foreach (DataRow mm in table.Rows)
                    {
                        DataRow w = drawTable.NewRow();
                        if (int.Parse(mm[2].ToString()) > t + 800 && int.Parse(mm[2].ToString()) < t + 900)
                        {
                            w["TYPE"] = (string)mm[1];
                            w["amp"] = int.Parse(mm[5].ToString());
                            w["time"] = int.Parse(mm[2].ToString());
                            w["Angle"] = Convert.ToDouble(mm[9].ToString());
                            w["Veloc"] = Convert.ToDouble(mm[10].ToString());
                            drawTable.Rows.Add(w);
                            sum2 += Convert.ToDouble(mm[9].ToString());
                            b += 1;
                        }
                    }
                    //计算旋转角度并显示
                    double Angle = sum2 / b;
                    

                    //旋转角度不同象限计算不同   分开计算表示
                    #region  270-360度
                    if (Convert.ToDouble(ss[9].ToString()) >= 270 && Convert.ToDouble(ss[9].ToString()) < 360)
                    {
                        if (Angle - Convert.ToDouble(ss[9].ToString()) <= 0)
                        {
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 30 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 75)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));

                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 60 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 110)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1500;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 90 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 140)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 120 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 165)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2500;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 145 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 205)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)3000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                        }
                        else
                        {
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 30 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 75)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 60 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 110)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1500;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 90 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 140)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 120 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 165)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2500;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 145 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 205)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)3000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }                          
                        }
                    }
                    #endregion

                    #region 180-270度
                    else if (Convert.ToDouble(ss[9].ToString()) >= 180 && Convert.ToDouble(ss[9].ToString()) < 270)
                    {
                        if (Angle - Convert.ToDouble(ss[9].ToString()) <= 0)
                        {
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 30 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 75)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 60 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 110)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1500;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 90 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 140)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 120 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 165)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2500;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 145 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 205)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)3000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            } 
                        }
                        else
                        { 
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 30 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 75)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 60 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 110)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1500;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 90 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 140)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 120 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 165)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2500;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 145 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 205)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)3000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                        }
                    }
                    #endregion

                    #region 90-180度
                    else if (Convert.ToDouble(ss[9].ToString()) >= 90 && Convert.ToDouble(ss[9].ToString()) < 180)
                    {
                        if (Angle - Convert.ToDouble(ss[9].ToString()) <= 0)
                        {
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 30 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 75)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 60 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 110)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1500;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 90 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 140)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 120 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 165)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2500;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 145 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 205)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)3000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                        }
                        else
                        {
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 30 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 75)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 60 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 110)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1500;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 90 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 140)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 120 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 165)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2500;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 145 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 205)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)3000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                        }
                    }
                    #endregion

                    #region 0-90度
                    else if (Convert.ToDouble(ss[9].ToString()) >= 0 && Convert.ToDouble(ss[9].ToString()) < 90)
                    {
                        if (Angle - Convert.ToDouble(ss[9].ToString()) <= 0)
                        {                
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 30 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 75)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 30 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 110)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1500;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 90 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 140)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 120 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 165)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2500;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 145 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 205)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)3000;
                                    ry[2] = Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Math.Abs(Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            
                        }
                        else
                        {
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 30 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 75)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 60 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 110)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)1500;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 90 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 140)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 120 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 165)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)2500;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (360 - (Angle - Convert.ToDouble(ss[9].ToString())) > 145 && 360 - (Angle - Convert.ToDouble(ss[9].ToString())) < 205)
                                {
                                    ry = tn.NewRow();
                                    ry[1] = (int)3000;
                                    ry[2] = 360 - (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tn.Rows.Add(ry);
                                    textBox1.AppendText(string.Format("左转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 - (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion

                //图XY坐标绑定

                chartForward.Series[0].Points.DataBindXY(tn.DefaultView, "ampL", tn.DefaultView, "AngL");
            }
        }
        #endregion


        #region 右转   800-900
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            drawTable.Clear();    //打开之前先把原表内容清空
            textBox1.Clear();          //打开之前先把提取数据内容清空
            rightTable.Clear();
            recordTable.Clear();
            chartForward.Series[0].Points.Clear();
            openRightFile();
        }

        DataTable dtRight = new DataTable();
        DataTable dtRight1 = new DataTable();
        //打开前进文件
        public void openRightFile()
        {
            ///////////////////--------打开xml文件，把文件反序列化到表内
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择文件";
            dialog.Filter = ("xml文件(*.xml)|*.xml");
            dialog.Multiselect = true;
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Data.DataTable));
            DataTable dt2;
            //当前选择文件的完整路径  循环获取多个打开的多个文件
            for (int FilesCount = 0; FilesCount < dialog.FileNames.Count(); FilesCount++)
            {
                string filePathName = dialog.FileNames[FilesCount];
                using (FileStream fs = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    dt2 = (DataTable)serializer.Deserialize(fs);  //反序列化xml文档
                }

                //如果选择多个数据  则循环遍历放到一个新的表内
                if (FilesCount >= 1)
                {
                    dtRight = dt2.Clone();
                    dtRight.Rows.Clear();
                    object[] obj = new object[dtRight.Columns.Count];
                    for (int i = 0; i < dtRight1.Rows.Count; i++)
                    {
                        dtRight1.Rows[i].ItemArray.CopyTo(obj, 0);
                        dtRight.Rows.Add(obj);
                    }
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        dt2.Rows[i].ItemArray.CopyTo(obj, 0);
                        dtRight.Rows.Add(obj);
                    }
                }
                else
                    dtRight = dt2;
                dtRight1 = dtRight;
            }
            recordTable = dtRight;
            dataExtractionRight(recordTable);
        }

        double sum3 = 0;    //前进刺激反应数据和
        int c = 0;//前进刺激反应个数和

        public void dataExtractionRight(DataTable table)
        {
            //前进表复制
            DataRow ru = null;
            DataTable tm = rightTable.Clone();
            tm.Rows.Clear();
            #region   人为添加点
            ru = tm.NewRow(); ru[1] = (int)1000; ru[2] = (int)75; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1000; ru[2] = (int)80; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1000; ru[2] = (int)40; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1000; ru[2] = (int)45; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1000; ru[2] = (int)51; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1000; ru[2] = (int)59; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1000; ru[2] = (int)67; tm.Rows.Add(ru);

            ru = tm.NewRow(); ru[1] = (int)1500; ru[2] = (int)117; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1500; ru[2] = (int)125; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1500; ru[2] = (int)77; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1500; ru[2] = (int)83; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1500; ru[2] = (int)90; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1500; ru[2] = (int)96; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1500; ru[2] = (int)104; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)1500; ru[2] = (int)111; tm.Rows.Add(ru);

            ru = tm.NewRow(); ru[1] = (int)2000; ru[2] = (int)150; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2000; ru[2] = (int)155; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2000; ru[2] = (int)100; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2000; ru[2] = (int)108; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2000; ru[2] = (int)117; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2000; ru[2] = (int)126; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2000; ru[2] = (int)133; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2000; ru[2] = (int)138; tm.Rows.Add(ru);

            ru = tm.NewRow(); ru[1] = (int)2500; ru[2] = (int)125; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2500; ru[2] = (int)180; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2500; ru[2] = (int)133; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2500; ru[2] = (int)140; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2500; ru[2] = (int)147; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2500; ru[2] = (int)150; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)2500; ru[2] = (int)155; tm.Rows.Add(ru);

            ru = tm.NewRow(); ru[1] = (int)3000; ru[2] = (int)158; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)3000; ru[2] = (int)164; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)3000; ru[2] = (int)171; tm.Rows.Add(ru);
            ru = tm.NewRow(); ru[1] = (int)3000; ru[2] = (int)180; tm.Rows.Add(ru);
            #endregion

            ///////////////////--------遍历表行数据集合
            foreach (DataRow ss in table.Rows)
            {
                DataRow r = drawTable.NewRow();   //实例化必须放在表内，否则报错已经存在这行数据了
                                                  //判断右转刺激
                if ((string)ss[1] == "DIRECTION_RIGHT")
                {
                    r["TYPE"] = (string)ss[1];
                    r["amp"] = int.Parse(ss[5].ToString());
                    r["time"] = int.Parse(ss[2].ToString());
                    r["Angle"] = Convert.ToDouble(ss[9].ToString());
                    r["Veloc"] = Convert.ToDouble(ss[10].ToString());
                    drawTable.Rows.Add(r);

                    int t = int.Parse(ss[2].ToString());
                    foreach (DataRow mm in table.Rows)
                    {
                        DataRow e = drawTable.NewRow();
                        if (int.Parse(mm[2].ToString()) > t + 800 && int.Parse(mm[2].ToString()) < t + 900)
                        {
                            e["TYPE"] = (string)mm[1];
                            e["amp"] = int.Parse(mm[5].ToString());
                            e["time"] = int.Parse(mm[2].ToString());
                            e["Angle"] = Convert.ToDouble(mm[9].ToString());
                            e["Veloc"] = Convert.ToDouble(mm[10].ToString());
                            drawTable.Rows.Add(e);
                            sum3 += Convert.ToDouble(mm[9].ToString());
                            c += 1;
                        }
                    }
                    double Angle = sum3 / c;



                    //旋转角度不同象限计算不同   分开计算表示
                    #region 270-360度
                    if (Convert.ToDouble(ss[9].ToString()) >= 270 && Convert.ToDouble(ss[9].ToString()) < 360)
                    {
                        if (Angle - Convert.ToDouble(ss[9].ToString()) >= 0)
                        {
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 40 && Angle - Convert.ToDouble(ss[9].ToString()) < 80)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 70 && Angle - Convert.ToDouble(ss[9].ToString()) < 125)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1500;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 100 && Angle - Convert.ToDouble(ss[9].ToString()) < 155)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 125 && Angle - Convert.ToDouble(ss[9].ToString()) < 180)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2500;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 150 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 220)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)3000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                        }
                        else
                        {
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 40 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 80)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 70 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 125)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1500;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 100 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 155)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 125 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 180)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2500;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 150 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 220)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)3000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                        }
                    }
                    #endregion

                    #region 180-270度
                    else if (Convert.ToDouble(ss[9].ToString()) >= 180 && Convert.ToDouble(ss[9].ToString()) < 270)
                    {
                        if (Angle - Convert.ToDouble(ss[9].ToString()) >= 0)
                        {
                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 40 && Angle - Convert.ToDouble(ss[9].ToString()) < 80)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 70 && Angle - Convert.ToDouble(ss[9].ToString()) < 125)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1500;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 100 && Angle - Convert.ToDouble(ss[9].ToString()) < 155)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 125 && Angle - Convert.ToDouble(ss[9].ToString()) < 180)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2500;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 150 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 220)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)3000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                        }
                        else
                        {

                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 40 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 80)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 70 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 125)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1500;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 100 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 155)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 125 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 180)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2500;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 150 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 220)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)3000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                        }
                    }
                    #endregion

                    #region 90-180度
                    else if (Convert.ToDouble(ss[9].ToString()) >= 90 && Convert.ToDouble(ss[9].ToString()) < 180)
                    {
                        if (Angle - Convert.ToDouble(ss[9].ToString()) >= 0)
                        {

                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 40 && Angle - Convert.ToDouble(ss[9].ToString()) < 80)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 70 && Angle - Convert.ToDouble(ss[9].ToString()) < 125)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1500;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 100 && Angle - Convert.ToDouble(ss[9].ToString()) < 155)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 125 && Angle - Convert.ToDouble(ss[9].ToString()) < 180)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2500;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 150 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 220)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)3000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                        }
                        else
                        {

                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 40 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 80)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 70 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 125)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1500;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 100 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 155)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 125 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 180)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2500;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 150 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 220)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)3000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                        }
                    }
                    #endregion

                    #region 0-90度
                    else if (Convert.ToDouble(ss[9].ToString()) >= 0 && Convert.ToDouble(ss[9].ToString()) < 90)
                    {
                        if (Angle - Convert.ToDouble(ss[9].ToString()) >= 0)
                        {

                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 40 && Angle - Convert.ToDouble(ss[9].ToString()) < 80)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 70 && Angle - Convert.ToDouble(ss[9].ToString()) < 125)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1500;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 100 && Angle - Convert.ToDouble(ss[9].ToString()) < 155)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (Angle - Convert.ToDouble(ss[9].ToString()) > 125 && Angle - Convert.ToDouble(ss[9].ToString()) < 180)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2500;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) > 150 && Math.Abs(Angle - Convert.ToDouble(ss[9].ToString())) < 220)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)3000;
                                    ru[2] = Angle - Convert.ToDouble(ss[9].ToString());
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", Angle - Convert.ToDouble(ss[9].ToString())));
                                }
                            }
                        }
                        else
                        {

                            if (int.Parse(ss[5].ToString()) >= 1000 && int.Parse(ss[5].ToString()) <= 1200)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 40 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 80)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1200 && int.Parse(ss[5].ToString()) <= 1600)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 70 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 125)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)1500;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 1600 && int.Parse(ss[5].ToString()) <= 2200)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 100 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 155)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2200 && int.Parse(ss[5].ToString()) <= 2600)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 125 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 180)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)2500;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                            else if (int.Parse(ss[5].ToString()) > 2600 && int.Parse(ss[5].ToString()) <= 3000)
                            {
                                if (360 + (Angle - Convert.ToDouble(ss[9].ToString())) > 150 && 360 + (Angle - Convert.ToDouble(ss[9].ToString())) < 220)
                                {
                                    ru = tm.NewRow();
                                    ru[1] = (int)3000;
                                    ru[2] = 360 + (Angle - Convert.ToDouble(ss[9].ToString()));
                                    tm.Rows.Add(ru);
                                    textBox1.AppendText(string.Format("右转刺激电压：{0}\n", int.Parse(ss[5].ToString())));
                                    textBox1.AppendText(string.Format("旋转角度：{0}\n", 360 + (Angle - Convert.ToDouble(ss[9].ToString()))));
                                }
                            }
                        }
                    }
                    #endregion
                }
                //图XY坐标绑定
                chartForward.Series[0].Points.DataBindXY(tm.DefaultView, "ampR", tm.DefaultView, "AngR");
            }
        }
        #endregion


        #region 关闭事件
        private void FormDrawChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            drawTable.Clear();
            textBox1.Clear();       
            rightTable.Clear();
            forwardTable.Clear();
            leftTable.Clear();
            recordTable.Clear();
            chartForward.Series[0].Points.Clear();
            e.Cancel = true;  //不关闭窗口
            this.Hide();   //隐藏
        }
        #endregion

    }
}
