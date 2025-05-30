% Предикат для обработки тестов
process_events(Input, ResultStr) :-
    % Разделяем входную строку на линии
    split_string(Input, "\n", "", [NLine|EventLines]),
    % Преобразуем количество событий в число
    atom_number(NLine, N),
    % Парсим события
    parse_events(EventLines, Events),
    % Решаем задачу
    solve(N, Events, Result),
    % Преобразуем результат в строку для assert_result
    atomic_list_concat(Result, ' ', ResultStr).

% Основной предикат для обработки задачи
solve(_N, Events, Result) :-
    process_events(Events, 0, [], Result).

% Обработка списка событий
% База: пустой список событий, возвращаем аккумулированный результат в обратном порядке
process_events([], _, Acc, Result) :-
    reverse(Acc, Result).

% Событие: прибытие автобуса с Bi местами
process_events([b(Bi)|Rest], People, Acc, Result) :-
    % Проверяем, может ли Монокарп сесть
    (Bi > People -> CanBoard = 'YES' ; CanBoard = 'NO'),
    % Обновляем количество людей
    NewPeople is max(0, People - Bi),
    % Продолжаем обработку
    process_events(Rest, NewPeople, [CanBoard|Acc], Result).

% Событие: прибытие Pi человек
process_events([p(Pi)|Rest], People, Acc, Result) :-
    % Увеличиваем количество людей на остановке
    NewPeople is People + Pi,
    % Продолжаем обработку
    process_events(Rest, NewPeople, Acc, Result).

% Парсинг списка строк событий
parse_events([], []) :- !.
parse_events([Line|Rest], [Event|Events]) :-
    parse_event(Line, Event),
    parse_events(Rest, Events).

% Парсинг строки события: P N или B N
parse_event(Line, Event) :-
    split_string(Line, " ", "", [Type, NStr]),
    atom_number(NStr, N),
    ( Type = "P" -> Event = p(N)
    ; Type = "B" -> Event = b(N)
    ),
    !.