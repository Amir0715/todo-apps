import { Todo } from "../stores/Todo";
import { ITodo } from "../types/types";

export function get_todos(): Todo[] {
    // TODO: Получаем элементы и возвращаем
    return [new Todo("Second Todo", false)];
}

export function delete_todos(id: string): boolean {
    // TODO: Удаляем элемент и возвращаем результат
    return false;
}

export function get_todo(id: string): ITodo {
    // TODO: Получаем элемент
    return new Todo("Third Todo", true);
}

export function create_todos(todo: ITodo): string {
    // TODO: Создаем элемент и возвращаем его id
    return "";
}

export function update_todo(todo: ITodo): boolean {
    // TODO: Обновляем элемент
    return false;
}
