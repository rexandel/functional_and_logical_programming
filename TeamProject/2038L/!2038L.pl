min_boards(N, MinBoards) :-
    UpperBound is ceiling(N * 18 / 60) + ceiling(N * 21 / 60) + ceiling(N * 25 / 60),
    
    between(1, UpperBound, MinBoards),
    can_cut_boards(MinBoards, N, 18, N, 21, N, 25),
    !.

can_cut_boards(TotalBoards, Need18, Len18, Need21, Len21, Need25, Len25) :-
    generate_cutting_combinations(TotalBoards, Need18, Len18, Need21, Len21, Need25, Len25, [], Combinations),
    member(combination(Got18, Got21, Got25), Combinations),
    Got18 >= Need18,
    Got21 >= Need21,
    Got25 >= Need25.

generate_cutting_combinations(0, _, _, _, _, _, _, Acc, Acc) :- !.

generate_cutting_combinations(BoardsLeft, Need18, Len18, Need21, Len21, Need25, Len25, Acc, Result) :-
    BoardsLeft > 0,
    generate_single_board_cuts(60, Len18, Len21, Len25, Cut18, Cut21, Cut25),
    
    (   Acc = [] ->
        NewAcc = [combination(Cut18, Cut21, Cut25)]
    ;   update_combinations(Acc, Cut18, Cut21, Cut25, NewAcc)
    ),
    
    BoardsLeft1 is BoardsLeft - 1,
    generate_cutting_combinations(BoardsLeft1, Need18, Len18, Need21, Len21, Need25, Len25, NewAcc, Result).

generate_single_board_cuts(BoardLength, Len18, Len21, Len25, Cut18, Cut21, Cut25) :-
    Max18 is BoardLength // Len18,
    between(0, Max18, Cut18),
    Remaining1 is BoardLength - Cut18 * Len18,
    
    Max21 is Remaining1 // Len21,
    between(0, Max21, Cut21),
    Remaining2 is Remaining1 - Cut21 * Len21,
    
    Max25 is Remaining2 // Len25,
    between(0, Max25, Cut25),
    
    UsedLength is Cut18 * Len18 + Cut21 * Len21 + Cut25 * Len25,
    UsedLength =< BoardLength.

update_combinations([], Cut18, Cut21, Cut25, [combination(Cut18, Cut21, Cut25)]).

update_combinations([combination(Acc18, Acc21, Acc25)|Rest], Cut18, Cut21, Cut25, 
                   [combination(New18, New21, New25)|NewRest]) :-
    New18 is Acc18 + Cut18,
    New21 is Acc21 + Cut21,
    New25 is Acc25 + Cut25,
    update_combinations(Rest, Cut18, Cut21, Cut25, NewRest).
