namespace LAB2KG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string prav = "F+F-F-FF+F+F-F";//�������
        int ugol = 90;
        string str = "F+F+F+F";//��������� ������
        int lx = 2, ly = 2;
        int x = 1100, y = 300;

        public void StrokaUPDATE()//��������� ������ str �������� �������� L-�������.
                                  //�������� ������ ������ 'F' � ������ str �� ������� prav, ��� ��������� ������ ��� ���������.

        {
            for (int a = 0; a < str.Length; a++)
            {
                int index = a;
                if (str[a] == 'F')
                {
                    str = str.Insert(a, prav);
                    index += 13;
                    str = str.Remove(index, 1);
                }
                a = index;
            }
        }
        public void Risovanie(Graphics g) //��������� �������� �� ����������� ������� g.
                                          //�� ���� �� ������� ������� � ������ str, ������� ���� �������� � ������� ����� Drow(g) ��� ��������� �����.
        {
            for (int a = 0; a < str.Length; a++)
            {
                if (str[a] == '-')
                {
                    ugol -= 90;
                }
                if (str[a] == '+')
                {
                    ugol += 90;
                }
                if (str[a] == 'F')
                {
                    Drow(g);
                }
            }
            StrokaUPDATE();
        }
        public void Drow(Graphics g)//������ ����� �� ����������� ������� g � ����������� �� �������� ���� �������� ugol.
                                    //����� LiniaRisov(g, lx, ly) ������������ ��� ��������� �����.
        {
            while (ugol > 360)
            {
                ugol -= 360;
            }
            while (ugol < -360)
            {
                ugol += 360;
            }
            if (ugol == 90 || ugol == -270)
            {
                LiniaRisov(g, 0, ly);
            }
            if (ugol == -90 || ugol == 270)
            {
                LiniaRisov(g, 0, -ly);
            }
            if (ugol == 180 || ugol == -180)
            {
                LiniaRisov(g, -lx, 0);
            }
            if (ugol == 0 || ugol == -360 || ugol == 360)
            {
                LiniaRisov(g, lx, 0);
            }

        }

        public void LiniaRisov(Graphics g, int lx, int ly)//������������ ��� ��������� �����.
        {
            g.DrawLine(Pens.Black, x, y, x + lx, y + ly);
            x += lx;
            y += ly;
        }
        public void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle); //������� ����� ������ Graphics �� ���������� ����������� ����.
            g.Clear(Color.White);
            Risovanie(g);
            x = 1100; y = 300;
        }
        
    }
}