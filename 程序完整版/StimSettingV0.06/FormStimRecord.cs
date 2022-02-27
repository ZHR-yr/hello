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
using System.Windows.Controls;
using System.Windows;

namespace StimSettingV0._06
{

    public delegate void Mydel(string path);   //声明一个委托类型
                                               //delegate void MyDel(int value);    声明委托类型
    public partial class FormStimRecord : Form    //Form表示组成应用程序的用户界面的窗口或对话框
    {
        public FormStimRecord()
        {
            InitializeComponent();   //加载各个组件
            recordTableInit();       //数据表的初始化
                    
        }

        #region  初始化数据表列的标题和格式
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
            column.ReadOnly = true;
            column.AutoIncrement = true;
            tb.Columns.Add(column);
            //TYPE列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");// 1 动作类型:   stimR stimL stimRF stimLF  posRecord
            column.AllowDBNull = false;
            column.Caption = "TYPE";
            column.ColumnName = "TYPE";
            column.ReadOnly = true;
            tb.Columns.Add(column);
            //time列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 2 Time /ms 动作发生时间  
            column.AllowDBNull = false;
            column.Caption = "time";
            column.ColumnName = "time";
            column.ReadOnly = true;
            tb.Columns.Add(column);
            //posX列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Single");// 3 X坐标，
            column.AllowDBNull = false;
            column.Caption = "posX";
            column.ColumnName = "posX";
            column.ReadOnly = true;
            tb.Columns.Add(column);
            //posY列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Single");// 4 Y坐标，
            column.AllowDBNull = false;
            column.Caption = "posY";
            column.ColumnName = "posY";
            column.ReadOnly = true;
            tb.Columns.Add(column);
            //amp列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 5 Amp 电压幅度mV
            //column.AllowDBNull = false;                                                     
            column.Caption = "Amp";
            column.ColumnName = "Amp";
            column.ReadOnly = true;
            tb.Columns.Add(column);
            //T列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 6 T 高电平持续时间 ms
            //column.AllowDBNull = false;
            column.Caption = "T";
            column.ColumnName = "T";
            column.ReadOnly = true;
            tb.Columns.Add(column);
            //Tw列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 7 Tw 单个小脉冲周期 ms
            //column.AllowDBNull = false;
            column.Caption = "Tw";
            column.ColumnName = "Tw";
            column.ReadOnly = true;
            tb.Columns.Add(column);
            //N列的设置----------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");// 8 N 一组脉冲的重复次数
            column.Caption = "N";
            column.ColumnName = "N";
            column.ReadOnly = true;
            tb.Columns.Add(column);
            //Angle列的设置------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Single");// 9 角度
            column.Caption = "Angle";
            column.ColumnName = "Angle";
            column.ReadOnly = true;
            tb.Columns.Add(column);//System.Single
            //Veloc列的设置------------------------------------------
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Single");// 9 角度
            column.Caption = "Veloc";
            column.ColumnName = "Veloc";
            column.ReadOnly = true;
            tb.Columns.Add(column);//System.Single

            ///////////////////////////////////////////////////////////
            recordTable = tb.Clone();     //克隆tb的数据结构
            dataGridView1.DataSource = recordTable;   //DataSource获取或设置 DataGridView 所显示数据的数据源
            recordTable.TableName = "recordTable";    //数据表的名称
        }
        #endregion


        #region   三个按钮事件
        public Mydel saveCanves;   //声明一个委托变量

        string filePathName = "";
        //存数据文件的储路径
        //object sender:表示触发事件的控件对象
        //sender是例子中触发单击事件的那个button控件
        //EventArgs e：表示事件数据的类的基类
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            string cmdName = ((ToolStripButton)sender).Text;   //获取点击按钮的文本

            if (cmdName == "打开")
            {
                OpenFileDialog dialog = new OpenFileDialog();   //OpenFileDialog提示用户打开文件
                                                                //dialog.Title = "请选择文件";   //文件或对话框标题
                dialog.Title = "请选择文件";
                dialog.Filter = ("xml文件(*.xml)|*.xml");  //获取或创建xml文件的数据流

                //如果用户点击的不是ok，函数不再执行
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    //ShowDialog将窗体显示为一个模式对话框。
                    //DialogResult指定标识符以指示对话框的返回值。OK通常从标签为“确定”的按钮发送
                    //如果按下的按钮不是确定，函数不再执行
                    return;
                }

                //获取用户打开文件的全路径，包括目录和文件名
                filePathName = dialog.FileName;

                //将对象序列化到xml文档中和xml文档反序列化到对象
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Data.DataTable));
                //Serialization.XmlSerializer将对象序列化到XML文档中和XML文档中反序列化对象
                //序列化就是把杂乱的数据整理清晰  例如<ID><TYPE>
                //serializer序列化工具
                DataTable dt;
                //using执行完大括号内的内容就释放
                using (FileStream fs = new FileStream(filePathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    dt = (DataTable)serializer.Deserialize(fs);  //反序列化xml文档
                }
                recordTable = dt;
                dataGridView1.DataSource = recordTable;
            }
            else if (cmdName == "保存")
            {
                saveDataFile(filePathName);
            }
            else if (cmdName == "另存为")
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "请选择文件";
                dialog.Filter = ("xml文件(*.xml)|*.xml");
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                filePathName = dialog.FileName;
                saveDataFile(filePathName);
            }
        }

        void saveDataFile(string path)
        {
            if (path == "")
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "请选择文件";
                dialog.Filter = ("xml文件(*.xml)|*.xml");
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                path = dialog.FileName;
            }
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Data.DataTable));
                System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(path);  //打开路径管道

                serializer.Serialize(writer, recordTable);   //将recordTable序列化写成XML文件  往管道里写

                writer.Close();   //关闭管道
                path = path.Substring(0, path.Length - 4) + ".png";
                saveCanves(path);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region  关闭事件
        private void FormStimRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;  //不关闭窗口
            this.Hide();   //隐藏
        }

        #endregion


        #region   窗体加载事件
        private void FormStimRecord_Load(object sender, EventArgs e)
        {

        }
        #endregion


        #region   数据分析按钮
        FormDrawChart formDrawChart = new FormDrawChart();
        private void toolStripButtondataanalysis_Click(object sender, EventArgs e)
        {
            
            formDrawChart.Show();
        }
        #endregion

        
    }
}

