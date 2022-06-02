namespace Training_Records_Management_System
{
    public class Charts
    {
        public string[] subjects { get; set; }
        public ChartData[] chartDatas{ get; set; }
}

    public class ChartData
    {
        public string name { get; set; }
        public int[] marks { get; set; }
    }
}
