namespace LAB2KG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string prav = "F+F-F-FF+F+F-F";//правило
        int ugol = 90;
        string str = "F+F+F+F";//начальная строка
        int lx = 2, ly = 2;
        int x = 1100, y = 300;

        public void StrokaUPDATE()//обновляет строку str согласно правилам L-системы.
                                  //заменяет каждый символ 'F' в строке str на правило prav, что расширяет строку для рисования.

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
        public void Risovanie(Graphics g) //рисование фрактала на графическом объекте g.
                                          //Он идет по каждому символу в строке str, изменяя угол поворота и вызывая метод Drow(g) для рисования линий.
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
        public void Drow(Graphics g)//рисует линию на графическом объекте g в зависимости от текущего угла поворота ugol.
                                    //Метод LiniaRisov(g, lx, ly) используется для рисования линий.
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

        public void LiniaRisov(Graphics g, int lx, int ly)//используется для рисования линий.
        {
            g.DrawLine(Pens.Black, x, y, x + lx, y + ly);
            x += lx;
            y += ly;
        }
        public void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle); //Создает новый объект Graphics из указанного дескриптора окна.
            g.Clear(Color.White);
            Risovanie(g);
            x = 1100; y = 300;
        }
        
    }
}