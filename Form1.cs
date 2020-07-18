using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string IFID = "";
        string IDEX = "";
        string EXMEM = "";
        string MEMWB = "";

        string EmptyReg = "????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????";
        string R_type = "000000";

        Dictionary<UInt32, string> DataMemory = new Dictionary<UInt32, string>();
        Dictionary<int, string> Instructions = new Dictionary<int, string>();
        Dictionary<int, int> MipsReg_Value = new Dictionary<int, int>();
        int Ins_Length = 0;
        int Cycle0_end = 0;
        int Cycle1_end = 0;
        int Cycle2_end = 0;
        int Cycle3_end = 0;
        int Cycle4_end = 0;
        
        private void Initialize_btn_Click(object sender, EventArgs e)
        {
            
            PiplineReg_gridview.Rows.Clear();
            DataMemory_gridview.Rows.Clear();
            mipsReg_gridview.Rows.Clear();
            DataMemory.Clear();
            Instructions.Clear();
            MipsReg_Value.Clear();
            //MipsReg_Value.Clear();

            pc_txtbox.Text = "1000";
          
            string[] MachineCode = usercode_txtbox.Text.ToString().Split('\n');
            Ins_Length = MachineCode.Length;
            Cycle0_end = Ins_Length;
            Cycle1_end = Ins_Length;
            Cycle2_end = Ins_Length;
            Cycle3_end = Ins_Length;
            Cycle4_end = Ins_Length;
            foreach (var item in MachineCode)
            {
                string[] inst = item.Split(':','\r');
                Instructions.Add(Convert.ToInt32(inst[0]), inst[1]);
            }

            //***************************************
            mipsReg_gridview.Rows.Add("$0", 0);
            MipsReg_Value.Add(0, 0);
            for (int i = 1; i <= 31; i++)
            {
                MipsReg_Value.Add(i, i + 100);
                mipsReg_gridview.Rows.Add("$" + i.ToString(), (i + 100));
            }
            //*************************
            IFID = EmptyReg;
            IDEX = EmptyReg;
            EXMEM = EmptyReg;
            MEMWB = EmptyReg;
           // PiplineReg_gridview.Rows.Add("IF/ID", IFID);
           // PiplineReg_gridview.Rows.Add("ID/EX", IDEX);
           // PiplineReg_gridview.Rows.Add("EX/MEM", EXMEM);
           // PiplineReg_gridview.Rows.Add("MEM/WB", MEMWB);
            //*******************************
            string _99 = "1100011";
            for (UInt32 i = 0; i < 500; i++)
            {
               // DataMemory_gridview.Rows.Add(i, 99);
                _99 = Upto(32, _99);
                DataMemory.Add(i,_99);
            }
        }
       
        private void RunCycle_btn_Click(object sender, EventArgs e)
        {
            
            string Curr_Ins = "";
            if (Instructions.ContainsKey(Convert.ToInt32(pc_txtbox.Text))== true){
                Curr_Ins = Instructions[Convert.ToInt32(pc_txtbox.Text)];
            }

            string Controls = "?????????";
            string ALUop = "??";
            string Function = IFID.Substring(58, 6);

            ALUop = GetALUop(Function);
            Controls = GetControl(ALUop);

            //initialize Piple line Registers 
            if (Cycle4_end > 0 && MEMWB[1] != '?')
            {
                try
                {
                    string Key = "";
                    char memtoreg = MEMWB[1];
                    if (memtoreg == '1') Key = DataMemory[Convert.ToUInt32(MEMWB.Substring(2, 32), 2)]; //load 
                    else Key = MEMWB.Substring(34, 32); //r-type  

                    string WriteReg_Val = MEMWB.Substring(66, 5);

                    MipsReg_Value[Convert.ToInt32(WriteReg_Val, 2)] = Convert.ToInt32(Key, 2);
                    mipsReg_gridview.Rows.Clear();
                    foreach (var item in MipsReg_Value)
                    {
                        mipsReg_gridview.Rows.Add(item.Key, item.Value);
                    }
                    Cycle4_end--;
                }
                catch (Exception)
                {}
            }

            if (Cycle3_end > 0 && EXMEM.Substring(3, 2) != "??")
            {
                try
                {   // MEM/WB Register
                    if (EXMEM.Substring(3, 2) == "10") //i-type
                    {
                        UInt32 x = Convert.ToUInt32(EXMEM.Substring(38, 32), 2);
                        MEMWB = "11" + DataMemory[x] + EXMEM.Substring(38, 32) + EXMEM.Substring(102, 5);
                        DataMemory_gridview.Rows.Add(x, 99);
                    }
                    else //R-type
                    {
                        MEMWB = "10" + "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" + EXMEM.Substring(38, 32) + EXMEM.Substring(102, 5);
                    }
                    Cycle3_end--;
                }
                catch (Exception)
                {}
            }

            if (Cycle2_end > 0 && IDEX.Substring(0, 5)!="?????")
            {

                try
                {   // EX/MEM Register
                    string operation = AluControl(IDEX.Substring(6, 2), IDEX.Substring(131, 6));
                    string ALuRes = GetALU_Res(operation);
                    string res = "";
                    ALuRes = Upto(32, ALuRes);
                    char RegDest = IDEX.ElementAt(5);
                    if (RegDest == '1')
                        res = IDEX.Substring(142, 5); //rt
                    else
                        res = IDEX.Substring(137, 5);  // rd

                    EXMEM = IDEX.Substring(0, 5) + "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" + "X" + ALuRes + IDEX.Substring(73, 32) + res;
                    Cycle2_end--;
                }
                catch (Exception)
                {}

            }

            if ( Cycle1_end > 0 && IFID.Substring(32, 6) != "??????")
            {
                try
                {
                    // IDEX Register
                    string RS_Reg = Convert.ToString(MipsReg_Value[Convert.ToInt32(IFID.Substring(38, 5), 2)], 2);
                    string RD_Reg = IFID.Substring(48, 5);
                    RS_Reg = Upto(32, RS_Reg);

                    if (IFID.Substring(32, 6) == R_type)
                    {
                        string RT_Reg;
                        RT_Reg = Convert.ToString(MipsReg_Value[Convert.ToInt32(IFID.Substring(43, 5), 2)], 2);
                        RT_Reg = Upto(32, RT_Reg);
                        IDEX = Controls + IFID.Substring(0, 32) + RS_Reg + RT_Reg + Upto(32, IFID.Substring(48, 16)) + "XXXXX" + RD_Reg;
                    }
                    else
                        IDEX = Controls + IFID.Substring(0, 32) + RS_Reg + "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" + Upto(32, IFID.Substring(48, 16)) + IFID.Substring(43, 5) + "XXXXX";

                    Cycle1_end--;
                }
                catch (Exception)
                {}
            }

            if (Cycle0_end > 0)
            {
                // IFID Register
                try
                {
                    int PCVal = Convert.ToInt32(pc_txtbox.Text) + 4;
                    IFID = Convert.ToString(PCVal, 2) + Curr_Ins;
                    IFID = Upto(64, IFID);
                    pc_txtbox.Text = Convert.ToInt32(IFID.Substring(0, 32), 2).ToString();
                    Cycle0_end--;
                }
                catch (Exception)
                {}
            }
            bool finish = false;   
            if (Cycle1_end == 0)
                IFID = EmptyReg;
            if (Cycle2_end == 0)
                IDEX = EmptyReg;
            if (Cycle3_end == 0)
                EXMEM = EmptyReg;
            if (Cycle4_end == 0)
            {
                MEMWB = EmptyReg;
                finish = true;
            }
            update_Pipline();
            if(finish)
                MessageBox.Show("Finished");
            
        }
        //**********************************************************************************************
        string AluControl(string aluop, string func)
        {
            string field = func.Substring(2, 4);
            if (aluop == "00" || field == "0000") return "0010";
            else if (field == "0010") return "0110";
            else if (field == "0100") return "0000";
            else if (field == "0101") return "0001";
            else return "????";
        }
        string GetALUop(string func)
        {
            if (func == "100100" || func == "100101" || func == "100000" || func == "100010") return "10";
            else return "00";
        }
        string GetControl(string ALUOP)
        {
            if (ALUOP == "10") return "100001100";
            else return "110100001";
        }

        string Upto(int size, string obj)
        {
            string s = "";
            for (int i = 0; i < size - obj.Length; i++)
            {
                s += "0";
            }
            s += obj;
            return s;
        }
        string GetALU_Res(string op)
        {
            string ALU_res = "";
            string RS, RT;
            char ALuSRC = IDEX[8];
            RS = IDEX.Substring(41, 32);
            if (ALuSRC == '1')
                RT = IDEX.Substring(105, 32);
            else
                RT = IDEX.Substring(73, 32);

            if (op == "0000") 
            {
                int andres = Convert.ToInt32(RS, 2) & Convert.ToInt32(RT, 2);
                ALU_res = Convert.ToString(andres, 2);
            }
            if (op == "0001") 
            {
                int orres = Convert.ToInt32(RS, 2) | Convert.ToInt32(RT, 2);
                ALU_res = Convert.ToString(orres, 2);
            }
            if (op == "0010") 
            {
                int addres = Convert.ToInt32(RS, 2) + Convert.ToInt32(RT, 2);
                ALU_res = Convert.ToString(addres, 2);
            }
            if (op == "0110") 
            {
                int x = Convert.ToInt32(RS, 2) - Convert.ToInt32(RT, 2);
                ALU_res = Convert.ToString(x, 2);
            }
            return ALU_res;
        }
        void update_Pipline()
        {
            PiplineReg_gridview.Rows.Clear();
            /*if you need to make 4 lines for each reg*/
            //Four_lines();
            
            /*if you need to make each value in specific line*/
            Multiple_lines();
        }
        void Four_lines()
        {
            PiplineReg_gridview.Rows.Add("IF/ID", IFID);
            PiplineReg_gridview.Rows.Add("ID/EX", IDEX);
            PiplineReg_gridview.Rows.Add("EX/MEM", EXMEM);
            PiplineReg_gridview.Rows.Add("MEM/WB", MEMWB);
        }
        void Multiple_lines()
        {
            //IFID
            try
            {
                PiplineReg_gridview.Rows.Add("IFID-Adder1_output", Convert.ToInt32(IFID.Substring(0, 32), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("IFID-Adder1_output", IFID.Substring(0, 32));
            }

            PiplineReg_gridview.Rows.Add("IFID-Instruction[31-0]", IFID.Substring(32, 32));

            //IDEX
            PiplineReg_gridview.Rows.Add("IDEX-Controlles", IDEX.Substring(0, 9));
            try
            {
                PiplineReg_gridview.Rows.Add("IDEX-Adder1_output", Convert.ToInt32(IDEX.Substring(9, 32), 2));

            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("IDEX-Adder1_output", IDEX.Substring(9, 32));
            }

            try
            {
                PiplineReg_gridview.Rows.Add("IDEX-ReadData1", Convert.ToInt32(IDEX.Substring(41, 32), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("IDEX-ReadData1", IDEX.Substring(41, 32));
            }

            try
            {
                PiplineReg_gridview.Rows.Add("IDEX-ReadData2", Convert.ToInt32(IDEX.Substring(73, 32), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("IDEX-ReadData2", IDEX.Substring(73, 32));
            }

            PiplineReg_gridview.Rows.Add("IDEX-Instr[15-0]", IDEX.Substring(105, 32));

            try
            {
                PiplineReg_gridview.Rows.Add("IDEX-Instr[20-16]", Convert.ToInt32(IDEX.Substring(137, 5), 2));
            }
            catch (Exception)
            {

                PiplineReg_gridview.Rows.Add("IDEX-Instr[20-16]", IDEX.Substring(137, 5));

            }

            try
            {
                PiplineReg_gridview.Rows.Add("IDEX-Instr[15-11]", Convert.ToInt32(IDEX.Substring(142, 5), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("IDEX-Instr[15-11]", IDEX.Substring(142, 5));
            }

            //EXMEM
            PiplineReg_gridview.Rows.Add("EXMEM-Controlles", EXMEM.Substring(0, 5));
            try
            {
                PiplineReg_gridview.Rows.Add("EXMEM-Adder2_output", Convert.ToInt32(EXMEM.Substring(5, 32), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("EXMEM-Adder2_output", EXMEM.Substring(5, 32));
            }

            PiplineReg_gridview.Rows.Add("EXMEM-Zero", EXMEM.Substring(37, 1));

            try
            {
                PiplineReg_gridview.Rows.Add("EXMEM-Alu_output", Convert.ToInt32(EXMEM.Substring(38, 32), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("EXMEM-Alu_output", EXMEM.Substring(38, 32));
            }

            try
            {
                PiplineReg_gridview.Rows.Add("EXMEM-Alu_mux_I/P_0", Convert.ToInt32(EXMEM.Substring(70, 32), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("EXMEM-Alu_mux_I/P_0", EXMEM.Substring(70, 32));
            }

            try
            {
                PiplineReg_gridview.Rows.Add("EXMEM-Reg_dest_mux_output", Convert.ToInt32(EXMEM.Substring(102, 5), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("EXMEM-Reg_dest_mux_output", EXMEM.Substring(102, 5));
            }

            //MEMWB
            PiplineReg_gridview.Rows.Add("MEMWB-Controlles", MEMWB.Substring(0, 2));

            try
            {
                PiplineReg_gridview.Rows.Add("MEMWB-Read_data", Convert.ToInt32(MEMWB.Substring(2, 32), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("MEMWB-Read_data", MEMWB.Substring(2, 32));
            }

            try
            {
                PiplineReg_gridview.Rows.Add("MEMWB-Adress", Convert.ToInt32(MEMWB.Substring(34, 32), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("MEMWB-Adress", MEMWB.Substring(34, 32));
            }

            try
            {
                PiplineReg_gridview.Rows.Add("MEMWB-Ex/mem_regrd", Convert.ToInt32(MEMWB.Substring(66, 5), 2));
            }
            catch (Exception)
            {
                PiplineReg_gridview.Rows.Add("MEMWB-Ex/mem_regrd", MEMWB.Substring(66, 5));
            }
        }
    }
}
