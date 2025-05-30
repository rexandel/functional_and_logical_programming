:- begin_tests(expression_fixer).

% (1) Тест на корректное исправление выражения с оператором '<'
test(fix_less_operator_correct) :-
    fix_expression_string("1<3", "1<3").

% (2) Тест на исправление выражения с неправильным оператором '<'
test(fix_less_operator_incorrect) :-
    fix_expression_string("1>3", "1<3").

% (3) Тест на корректное исправление выражения с оператором '>'
test(fix_greater_operator_correct) :-
    fix_expression_string("3>1", "3>1").

% (4) Тест на исправление выражения с неправильным оператором '>'
test(fix_greater_operator_incorrect) :-
    fix_expression_string("3=1", "3>1").

% (5) Тест на корректное исправление выражения с оператором '='
test(fix_equal_operator_correct) :-
    fix_expression_string("5=5", "5=5").

% (6) Тест на исправление выражения с неправильным оператором '='
test(fix_equal_operator_incorrect) :-
    fix_expression_string("5<5", "5=5").

% (7) Тест на обработку минимальных значений
test(fix_min_values) :-
    fix_expression_string("0>9", "0<9").

% (8) Тест на обработку максимальных значений
test(fix_max_values) :-
    fix_expression_string("9<0", "9>0").

% (9) Тест на нули с неправильным оператором
test(fix_zero_values) :-
    fix_expression_string("0>0", "0=0").

% (10) Тест на обработку цифр с разницей в 1
test(fix_diff_by_one) :-
    fix_expression_string("4=5", "4<5"),
    fix_expression_string("5=4", "5>4"),
    fix_expression_string("5>4", "5>4"),
    fix_expression_string("4<5", "4<5").

% Тест на некорректную длину ввода (ожидаем неудачу)
test(invalid_length, [fail]) :-
    fix_expression_string("12", _).

:- end_tests(expression_fixer).