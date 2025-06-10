generate_words(N, K, M, FileName) :-
	open(FileName, write, Stream),
	write(Stream, 'Words of length '), write(Stream, N),
	write(Stream, ' with '), write(Stream, K), write(Stream, ' letters f, '),
	write(Stream, M), write(Stream, ' letters c:'), nl(Stream),
	nl(Stream),
	generate_and_write_words(N, K, M, Stream),
	close(Stream),
	write('Results have been written to the file: '), write(FileName), nl.

generate_and_write_words(N, K, M, Stream) :-
    generate_word(N, K, M, Word),
    write_word(Stream, Word),
    fail.
generate_and_write_words(_, _, _, _).

generate_word(N, K, M, Word) :-
    length(Word, N),
    K + M =< N,
    fill_word(Word, K, M, N),
    check_word_constraints(Word, K, M).

fill_word(Word, K, M, N) :-
    Remaining is N - K - M,
    create_base_list(K, M, BaseList),
    OtherSymbols = [a, b, d, e],
    select_other_symbols(OtherSymbols, Remaining, SelectedOthers),
    append(BaseList, SelectedOthers, AllSymbols),
    length(AllSymbols, N),
    permutation(AllSymbols, Word).

create_base_list(K, M, BaseList) :-
    create_f_list(K, FList),
    create_c_list(M, CList),
    append(FList, CList, BaseList).

create_f_list(0, []) :- !.
create_f_list(K, [f|Rest]) :-
    K > 0,
    K1 is K - 1,
    create_f_list(K1, Rest).

create_c_list(0, []) :- !.
create_c_list(M, [c|Rest]) :-
    M > 0,
    M1 is M - 1,
    create_c_list(M1, Rest).

select_other_symbols(_, 0, []) :- !.
select_other_symbols(Available, Needed, Selected) :-
    Needed > 0,
    length(Available, AvailCount),
    Needed =< AvailCount,
    select_combination(Available, Needed, Selected).

select_combination(_, 0, []) :- !.
select_combination([H|T], N, [H|Rest]) :-
    N > 0,
    N1 is N - 1,
    select_combination(T, N1, Rest).
select_combination([_|T], N, Rest) :-
    N > 0,
    select_combination(T, N, Rest).

check_word_constraints(Word, K, M) :-
    count_occurrences(Word, f, K),
    count_occurrences(Word, c, M),
    check_other_letters(Word).

count_occurrences([], _, 0).
count_occurrences([H|T], Symbol, Count) :-
    (H = Symbol ->
        count_occurrences(T, Symbol, Count1),
        Count is Count1 + 1
    ;
        count_occurrences(T, Symbol, Count)
    ).

check_other_letters(Word) :-
    count_occurrences(Word, a, CountA), CountA =< 1,
    count_occurrences(Word, b, CountB), CountB =< 1,
    count_occurrences(Word, d, CountD), CountD =< 1,
    count_occurrences(Word, e, CountE), CountE =< 1.

write_word(Stream, Word) :-
    write_list(Stream, Word),
    nl(Stream).

write_list(_, []) :- !.
write_list(Stream, [H|T]) :-
    write(Stream, H),
    write_list(Stream, T).

show_words(N, K, M) :-
    generate_word(N, K, M, Word),
    write_list(user_output, Word), nl,
    fail.
show_words(_, _, _).

count_words(N, K, M, Count) :-
    findall(Word, generate_word(N, K, M, Word), Words),
    length(Words, Count).
