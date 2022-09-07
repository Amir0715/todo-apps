import { TodoStore } from "../stores/TodoStore";
import { ITodo } from "../types/types";

export function get_todos(): ITodo[] {
    // TODO: Получаем элементы и возвращаем
    return [new TodoStore()];
}

export function delete_todos(id: string): boolean {
    // TODO: Удаляем элемент и возвращаем результат
    return false;
}

export function get_todo(id: string): ITodo {
    // TODO: Получаем элемент
    return new TodoStore();
}

export function create_todos(todo: ITodo): string {
    // TODO: Создаем элемент и возвращаем его id
    return "";
}

export function update_todo(todo: ITodo): boolean {
    // TODO: Обновляем элемент
    return false;
}
