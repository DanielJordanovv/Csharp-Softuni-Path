using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        [Key]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        [Key]
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public byte ScoredGoals { get; set; }
        public byte Assists { get; set; }
        public byte MinutesPlayed { get; set; }
    }
}
