compare_digits(D1, D2, '<') :- D1 @< D2.
compare_digits(D1, D2, '>') :- D1 @> D2.
compare_digits(D, D, '=').

fix_expression([D1, _, D2], [D1, Op, D2]) :-
    number_chars(Number1, [D1]),
    number_chars(Number2, [D2]),
    compare_digits(Number1, Number2, Op).

string_to_list(String, List) :-
    string_chars(String, List).

list_to_string(List, String) :-
    string_chars(String, List).

fix_expression_string(Input, Output) :-
    string_to_list(Input, List),
    fix_expression(List, FixedList),
    list_to_string(FixedList, Output).