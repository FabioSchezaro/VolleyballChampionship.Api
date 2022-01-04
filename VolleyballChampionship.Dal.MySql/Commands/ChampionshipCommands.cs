namespace VolleyballChampionship.Dal.MySql.Commands
{
    public class ChampionshipCommands
    {
        public const string _sql = @"
                                    SELECT 
                                        * 
                                    FROM 
                                        Championship 
                                    WHERE 
                                        1 = 1";

        public const string _whereDescription = @"
                                    AND Description LIKE CONCAT ('%', @Description, '%')";

        public const string _whereStatus = @"
                                    AND Status = @Status";
    }
}
