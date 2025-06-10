calculate_boards(N, Result) :-
    (N =:= 1 -> Result = 2
    ;
    InitialBoards is N // 2,
    Remaining18 is N - (N // 2),
    
    (N mod 2 =\= 0 -> 
        Result1 is InitialBoards + 1,
        NewRemaining18 is Remaining18 - 2
    ;
        Result1 = InitialBoards,
        NewRemaining18 = Remaining18
    ),
    
    (NewRemaining18 > 0 ->
        AdditionalBoards is NewRemaining18 // 3,
        FinalRemaining18 is NewRemaining18 mod 3,
        Result2 is Result1 + AdditionalBoards
    ;
        Result2 = Result1,
        FinalRemaining18 = 0
    ),
    
    FinalCalculation is (FinalRemaining18 + N + 1) // 2,
    Result is Result2 + FinalCalculation
    ).

min_boards(N, Result) :-
    calculate_boards(N, Result).
