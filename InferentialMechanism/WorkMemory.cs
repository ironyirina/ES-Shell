namespace InferentialMechanism
{
    public class WorkMemory
    {
        public Variables Variable { get; set; }
        public Values Value { get; set; }
        public bool HasBeenAsked { get; set; }
    }
}
