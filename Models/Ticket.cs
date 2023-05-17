using System.ComponentModel.DataAnnotations;

namespace CertamenDW.Models
{
    public class Ticket
    {
        [Required(ErrorMessage = "Número de Ticket es requerido")]
        public int TicketNumber { get; set; }   
        [Required(ErrorMessage = "El asunto es requerido")]
        [MaxLength(25)]
        public string Subject { get; set; }    
        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(125)]
        public string Description { get; set; }
        public bool isOpen { get; set; }
        [Required(ErrorMessage = "Fecha de Creación es requerida")]
        public DateTime CreatedDate { get; set; }
        public DateTime ResolvedDate { get; set; }

        public Ticket()
        {
            TicketNumber = new Random().Next(1, 100);
            isOpen = true;
            CreatedDate = DateTime.Now;
            ResolvedDate = DateTime.MinValue;
        }
        public Ticket(int ticketNumber, string subject, string description)
        {
            TicketNumber = ticketNumber;
            Subject = subject;
            Description = description;
            isOpen = true;
            CreatedDate = DateTime.Now;
            ResolvedDate = DateTime.MinValue;
        }

        public void MarkAsResolved()
        {
            isOpen = false;
            ResolvedDate = DateTime.Now;
        }
    }
}
