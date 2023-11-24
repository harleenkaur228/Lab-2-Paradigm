type Coach = {
    Name: string
    formerPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

let teams = [
    { Name= "Dallas Mavericks"; Coach ={Name="Jason Kidd"; formerPlayer=true}; Stats= {Wins= 1747; Losses= 1714} }
    { Name= "Indiana Pacers"; Coach ={Name="Rick Carlisle"; formerPlayer=true}; Stats= {Wins= 1883; Losses= 1903} }
    { Name= "Houston Rockets"; Coach ={Name="Ime Udoka"; formerPlayer=false}; Stats= {Wins= 2328; Losses= 2196} }
    { Name= "Toronto Raptors"; Coach ={Name="Ime Udoka"; formerPlayer=false}; Stats= {Wins= 1071; Losses= 1157} }
    { Name= "Los Angeles Lakers"; Coach ={Name="Ime Udoka"; formerPlayer=false}; Stats= {Wins= 3503; Losses= 2419} }
]

let winningprcntge team =
    let totalGames = float (team.Stats.Wins + team.Stats.Losses)
    if totalGames = 0.0 then
        0.0 
    else
        (float team.Stats.Wins / totalGames) * 100.0

let winningprcntges = List.map winningprcntge teams

printfn "Winning Percentages:"
List.iter2 (fun team percentage ->
    printfn "Team: %s, Winning Percentage: %.2f%%" team.Name percentage
) teams winningprcntges


