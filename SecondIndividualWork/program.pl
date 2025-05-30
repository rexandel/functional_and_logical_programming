% Главный предикат для генерации слов и записи в файл
generate_words(N, K, M, FileName) :-
    open(FileName, write, Stream),
    write(Stream, 'Слова длины '), write(Stream, N),
    write(Stream, ' с '), write(Stream, K), write(Stream, ' буквами f, '),
    write(Stream, M), write(Stream, ' буквами c:'), nl(Stream),
    nl(Stream),
    generate_and_write_words(N, K, M, Stream),
    close(Stream),
    write('Результаты записаны в файл: '), write(FileName), nl.

% Предикат для генерации и записи всех подходящих слов
generate_and_write_words(N, K, M, Stream) :-
    generate_word(N, K, M, Word),
    write_word(Stream, Word),
    fail.
generate_and_write_words(_, _, _, _).

% Генерация одного слова с заданными ограничениями
generate_word(N, K, M, Word) :-
    % Создаем список нужной длины
    length(Word, N),
    % Проверяем, что K + M <= N (иначе невозможно)
    K + M =< N,
    % Заполняем слово символами
    fill_word(Word, K, M, N),
    % Проверяем корректность слова
    check_word_constraints(Word, K, M).

% Заполнение слова символами
fill_word(Word, K, M, N) :-
    % Вычисляем количество оставшихся позиций
    Remaining is N - K - M,
    % Создаем базовый список с f и c
    create_base_list(K, M, BaseList),
    % Добавляем остальные символы (a, b, d, e) - каждый максимум 1 раз
    OtherSymbols = [a, b, d, e],
    select_other_symbols(OtherSymbols, Remaining, SelectedOthers),
    % Объединяем списки
    append(BaseList, SelectedOthers, AllSymbols),
    % Проверяем, что общая длина соответствует N
    length(AllSymbols, N),
    % Генерируем перестановки
    permutation(AllSymbols, Word).

% Создание базового списка с K символами f и M символами c
create_base_list(K, M, BaseList) :-
    create_f_list(K, FList),
    create_c_list(M, CList),
    append(FList, CList, BaseList).

% Создание списка с K символами f
create_f_list(0, []) :- !.
create_f_list(K, [f|Rest]) :-
    K > 0,
    K1 is K - 1,
    create_f_list(K1, Rest).

% Создание списка с M символами c
create_c_list(0, []) :- !.
create_c_list(M, [c|Rest]) :-
    M > 0,
    M1 is M - 1,
    create_c_list(M1, Rest).

% Выбор других символов (максимум по одному)
select_other_symbols(_, 0, []) :- !.
select_other_symbols(Available, Needed, Selected) :-
    Needed > 0,
    length(Available, AvailCount),
    Needed =< AvailCount,
    select_combination(Available, Needed, Selected).

% Выбор комбинации символов
select_combination(_, 0, []) :- !.
select_combination([H|T], N, [H|Rest]) :-
    N > 0,
    N1 is N - 1,
    select_combination(T, N1, Rest).
select_combination([_|T], N, Rest) :-
    N > 0,
    select_combination(T, N, Rest).

% Проверка ограничений слова
check_word_constraints(Word, K, M) :-
    count_occurrences(Word, f, K),
    count_occurrences(Word, c, M),
    check_other_letters(Word).

% Подсчет вхождений символа в список
count_occurrences([], _, 0).
count_occurrences([H|T], Symbol, Count) :-
    (H = Symbol ->
        count_occurrences(T, Symbol, Count1),
        Count is Count1 + 1
    ;
        count_occurrences(T, Symbol, Count)
    ).

% Проверка, что остальные буквы (a, b, d, e) встречаются не более 1 раза
check_other_letters(Word) :-
    count_occurrences(Word, a, CountA), CountA =< 1,
    count_occurrences(Word, b, CountB), CountB =< 1,
    count_occurrences(Word, d, CountD), CountD =< 1,
    count_occurrences(Word, e, CountE), CountE =< 1.

% Запись слова в поток
write_word(Stream, Word) :-
    write_list(Stream, Word),
    nl(Stream).

% Запись списка как строки
write_list(_, []) :- !.
write_list(Stream, [H|T]) :-
    write(Stream, H),
    write_list(Stream, T).

% Вспомогательные предикаты для удобства использования

% Пример использования:
% ?- generate_words_to_file(4, 2, 1, 'output.txt').
% Генерирует все слова длины 4 с 2 буквами f, 1 буквой c

% Предикат для вывода на экран (для тестирования)
show_words(N, K, M) :-
    generate_word(N, K, M, Word),
    write_list(user_output, Word), nl,
    fail.
show_words(_, _, _).

% Подсчет общего количества слов
count_words(N, K, M, Count) :-
    findall(Word, generate_word(N, K, M, Word), Words),
    length(Words, Count).

% Примеры использования:
% 1. Генерация слов длины 3 с 1 буквой f и 1 буквой c:
%    ?- generate_words_to_file(3, 1, 1, 'words_3_1_1.txt').
%
% 2. Показать слова на экране:
%    ?- show_words(3, 1, 1).
%
% 3. Подсчитать количество слов:
%    ?- count_words(3, 1, 1, Count).