namespace GESTOR_TORNEOS.Domain.Entities;

public class Transfer
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public string? PlayerName { get; set; }
    public string? TransferType { get; set; }
    public int FromTeamId { get; set; }
    public int ToTeamId { get; set; }
    public DateTime TransferDate { get; set; }

    public Transfer(int id, int playerId, string? playerName, string? transferType, int fromTeamId, int toTeamId, DateTime transferDate)
    {
        Id = id;
        PlayerId = playerId;
        PlayerName = playerName;
        TransferType = transferType;
        FromTeamId = fromTeamId;
        ToTeamId = toTeamId;
        TransferDate = transferDate;
    }
    
    public Transfer() { }

    public override string ToString()
    {
        return $"Id: {Id}, PlayerId: {PlayerId}, PlayerName: {PlayerName}, TransferType: {TransferType}, FromTeamId: {FromTeamId}, ToTeamId: {ToTeamId}, TransferDate: {TransferDate}";
    }
}