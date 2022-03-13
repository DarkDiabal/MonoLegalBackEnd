
namespace MonoLegal.Core.Enums
{
    public class Reminder
    {
        public enum ReminderType
        {
            PrimerRecordatorio,
            SegundoRecordatorio,
            Desactivado
        }

        public struct ReminderTypeTemplate
        {
            public const string PrimerRecordatorio = "001";
            public const string SegundoRecordatorio = "002";
        }
    }
}
