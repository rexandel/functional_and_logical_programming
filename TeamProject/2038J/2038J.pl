% Основной предикат для обработки задачи
solve(N, Events, Result) :-
    write('Starting processing with '), write(N), write(' events.'), nl,
    process_events(Events, 0, [], Result).

% Обработка списка событий
% База: пустой список событий, возвращаем аккумулированный результат в обратном порядке
process_events([], _, Acc, Result) :-
    write('Finished processing events. Finalizing result.'), nl,
    reverse(Acc, Result).

% Событие: прибытие автобуса с Bi местами
process_events([b(Bi)|Rest], People, Acc, Result) :-
    write('Bus arrived with '), write(Bi), write(' seats. People waiting: '), write(People), nl,
    % Проверяем, может ли Монокарп сесть (есть ли место после посадки других людей)
    (Bi > People -> 
        CanBoard = 'YES', 
        write('Monocarp can board (seats > people). Result: YES'), nl
    ; 
        CanBoard = 'NO', 
        write('Monocarp cannot board (seats <= people). Result: NO'), nl
    ),
    % Обновляем количество людей: если мест меньше, чем людей, остаются People - Bi
    NewPeople is max(0, People - Bi),
    write('After bus, '), write(NewPeople), write(' people remain waiting.'), nl,
    % Продолжаем обработку с обновленным количеством людей
    process_events(Rest, NewPeople, [CanBoard|Acc], Result).

% Событие: прибытие Pi человек
process_events([p(Pi)|Rest], People, Acc, Result) :-
    write(''), write(Pi), write(' people arrived. People waiting before: '), write(People), nl,
    % Увеличиваем количество людей на остановке
    NewPeople is People + Pi,
    write('Now '), write(NewPeople), write(' people are waiting.'), nl,
    % Продолжаем обработку
    process_events(Rest, NewPeople, Acc, Result).

% Точка входа для чтения ввода и вывода результата
main :-
    write('Reading input...'), nl,
    % Читаем количество событий
    read_line_to_string(user_input, NLine),
    atom_number(NLine, N),
    write('Number of events: '), write(N), nl,
    % Читаем список событий
    read_events(N, Events),
    write('Events read: '), write(Events), nl,
    % Решаем задачу
    solve(N, Events, Result),
    % Выводим результат
    write('Outputting results:'), nl,
    write_result(Result).

% Чтение N событий
read_events(0, []) :- !.
read_events(N, [Event|Rest]) :-
    N > 0,
    % Читаем строку и парсим событие
    read_line_to_string(user_input, Line),
    parse_event(Line, Event),
    write('Read event: '), write(Event), nl,
    N1 is N - 1,
    read_events(N1, Rest).

% Парсинг строки события: P N или B N
parse_event(Line, p(N)) :-
    split_string(Line, " ", "", [P, NStr]),
    P = "P",
    atom_number(NStr, N).
parse_event(Line, b(N)) :-
    split_string(Line, " ", "", [B, NStr]),
    B = "B",
    atom_number(NStr, N).

% Вывод результата
write_result([]) :-
    write('Finished outputting results.'), nl.
write_result([X|Rest]) :-
    write('Result for bus: '), write(X), nl,
    write_result(Rest).