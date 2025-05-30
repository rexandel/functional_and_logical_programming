:- begin_tests(bus_stop).

% Вспомогательный предикат для сравнения результатов
assert_result(Expected, Actual) :-
    atomic_list_concat(Expected, ' ', ExpectedStr),
    ( Actual = ExpectedStr -> true ; format("Failed: Expected '~w', got '~w'~n", [ExpectedStr, Actual]), fail ).

% Тест 1: Только автобусы, нет людей
test(test1_only_buses_no_people) :-
    Input = "3\nB 2\nB 1\nB 3",
    process_events(Input, Result),
    assert_result(["YES", "YES", "YES"], Result).

% Тест 2: Только люди, нет автобусов
test(test2_only_people_no_buses) :-
    Input = "2\nP 5\nP 3",
    process_events(Input, Result),
    assert_result([], Result).

% Тест 3: Простой случай - Монокарп может сесть
test(test3_simple_case_monocarp_can_board) :-
    Input = "4\nP 2\nB 3\nP 1\nB 2",
    process_events(Input, Result),
    assert_result(["YES", "YES"], Result).

% Тест 4: Все люди помещаются точно
test(test4_all_people_fit_exactly) :-
    Input = "3\nP 5\nB 5\nB 1",
    process_events(Input, Result),
    assert_result(["NO", "YES"], Result).

% Тест 5: Больше людей, чем вместимость автобуса
test(test5_more_people_than_bus_capacity) :-
    Input = "3\nP 10\nB 4\nB 6",
    process_events(Input, Result),
    assert_result(["NO", "NO"], Result).

% Тест 6: Несколько автобусов с оставшимися людьми
test(test6_multiple_buses_with_remaining_people) :-
    Input = "5\nP 3\nB 2\nP 4\nB 3\nB 2",
    process_events(Input, Result),
    assert_result(["NO", "NO", "NO"], Result).

% Тест 7: Граничный случай - максимальное количество людей и вместимость автобуса
test(test7_edge_case_max_people_and_bus_capacity) :-
    Input = "2\nP 1000000\nB 1000000",
    process_events(Input, Result),
    assert_result(["NO"], Result).

% Тест 8: Граничный случай - один человек, один автобус
test(test8_edge_case_one_person_one_bus) :-
    Input = "2\nP 1\nB 1",
    process_events(Input, Result),
    assert_result(["NO"], Result).

% Тест 9: Чередующиеся люди и автобусы
test(test9_alternating_people_and_buses) :-
    Input = "6\nP 2\nB 1\nP 1\nB 2\nP 3\nB 3",
    process_events(Input, Result),
    assert_result(["NO", "NO", "NO"], Result).

% Тест 10: Сложный сценарий
test(test10_complex_scenario) :-
    Input = "7\nP 5\nB 3\nP 2\nB 4\nP 1\nB 2\nB 1",
    process_events(Input, Result),
    assert_result(["NO", "NO", "YES", "YES"], Result).

:- end_tests(bus_stop).