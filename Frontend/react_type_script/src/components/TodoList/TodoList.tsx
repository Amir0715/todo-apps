import * as React from 'react';
import TodoItem from '../TodoItem/TodoItem';
import { observer } from 'mobx-react';
import "./todoList.css";
import { Todo } from '../../stores/Todo';

export interface ITodoListProps {
    todos: Todo[],
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
