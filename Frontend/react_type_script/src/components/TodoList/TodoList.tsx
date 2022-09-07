import * as React from 'react';
import { ITodo } from '../../types/types';
import TodoItem from '../TodoItem/TodoItem';
import { observer } from 'mobx-react';
import "./todoList.css";

export interface ITodoListProps {
    todos: ITodo[],
}

const TodoList = observer(({ todos }: ITodoListProps) => {
    return (
        <div className="list">
            {todos.map(todo =>
                <TodoItem todo={todo} key={todo.id} />
            )}
        </div>
    );
});

export default TodoList;
