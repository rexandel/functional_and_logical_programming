:- begin_tests(expression_fixer).

test(fix_less_operator_correct) :-
    fix_expression_string("1<3", "1<3").

test(fix_less_operator_incorrect) :-
    fix_expression_string("1>3", "1<3").

test(fix_greater_operator_correct) :-
    fix_expression_string("3>1", "3>1").

test(fix_greater_operator_incorrect) :-
    fix_expression_string("3=1", "3>1").

test(fix_equal_operator_correct) :-
    fix_expression_string("5=5", "5=5").

test(fix_equal_operator_incorrect) :-
    fix_expression_string("5<5", "5=5").

test(fix_min_values) :-
    fix_expression_string("0>9", "0<9").

test(fix_max_values) :-
    fix_expression_string("9<0", "9>0").

test(fix_zero_values) :-
    fix_expression_string("0>0", "0=0").

test(fix_diff_by_one) :-
    fix_expression_string("4=5", "4<5"),
    fix_expression_string("5=4", "5>4"),
    fix_expression_string("5>4", "5>4"),
    fix_expression_string("4<5", "4<5").

test(invalid_length, [fail]) :-
    fix_expression_string("12", _).

:- end_tests(expression_fixer).