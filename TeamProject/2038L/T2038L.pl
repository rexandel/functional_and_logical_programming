:- begin_tests(board_calculator).

test(calculate_boards_n1) :- 
    min_boards(1, Result),
    assertion(Result =:= 2).

test(calculate_boards_n2) :- 
    min_boards(2, Result),
    assertion(Result =:= 3).

test(calculate_boards_n3) :- 
    min_boards(3, Result),
    assertion(Result =:= 4).

test(calculate_boards_n4) :- 
    min_boards(4, Result),
    assertion(Result =:= 5).

test(calculate_boards_n5) :- 
    min_boards(5, Result),
    assertion(Result =:= 6).

test(calculate_boards_n6) :- 
    min_boards(6, Result),
    assertion(Result =:= 7).

test(calculate_boards_n7) :- 
    min_boards(7, Result),
    assertion(Result =:= 9).

test(calculate_boards_n8) :- 
    min_boards(8, Result),
    assertion(Result =:= 10).

test(calculate_boards_n9) :- 
    min_boards(9, Result),
    assertion(Result =:= 11).

test(calculate_boards_n10) :- 
    min_boards(10, Result),
    assertion(Result =:= 12).

test(calculate_boards_n20_returns24) :- 
    min_boards(20, Result),
    assertion(Result =:= 24).

test(calculate_boards_n100_returns117) :- 
    min_boards(100, Result),
    assertion(Result =:= 117).

test(calculate_boards_n1000_returns1167) :- 
    min_boards(1000, Result),
    assertion(Result =:= 1167).

:- end_tests(board_calculator).