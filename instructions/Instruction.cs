public class Instruction
{
    public Instruction(string inst, int num){
      StepNumber = num;
      InstructionText = inst;
    }
    public int StepNumber { get; set; }
    public string InstructionText { get; set; }
}
