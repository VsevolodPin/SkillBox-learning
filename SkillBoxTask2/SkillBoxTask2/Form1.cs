namespace SkillBoxTask2
{
    public partial class Form1 : Form
    {
        string fullName;
        string email;

        int age;

        double prScore;
        double mScore;
        double phScore;

        double overallScore;
        double avgScore;

        public Form1()
        {
            InitializeComponent();

            UpdateValues();
        }

        private void UpdateValues()
        {
            fullName = Surname.Text + " " + NameTB.Text + " " + Patronymic.Text;
            email = Email.Text;

            age = Convert.ToInt32(Age.Text);

            prScore = ProgrScore.Text == "" ? 0.0 : Convert.ToDouble(ProgrScore.Text.Replace(".", ","));
            mScore = MathScore.Text == "" ? 0.0 : Convert.ToDouble(MathScore.Text.Replace(".", ","));
            phScore = PhysScore.Text == "" ? 0.0 : Convert.ToDouble(PhysScore.Text.Replace(".", ","));

            overallScore = prScore + mScore + phScore;
            avgScore = overallScore / 3;

            Result.Text =
                $"������ ���: {fullName}.\n" +
                $"�������: {age} ����.\n" +
                $"Email: {email}\n\n" +
                $"���������� �� ���������\n" +
                $"����������������: {prScore} ������\n" +
                $"����������: {mScore} ������\n" +
                $"������: {phScore} ������\n" +
                $"����� ����: {overallScore}\n" +
                $"������� ����: {avgScore.ToString("f2")}";
        }

        private void UpdateValuesEvent(object sender, EventArgs e)
        {
            UpdateValues();
        }
    }
}