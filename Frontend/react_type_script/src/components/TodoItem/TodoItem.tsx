import * as React from 'react';
import { ITodo } from '../../types/types';
import { observer } from 'mobx-react';
import "./todoItem.css";

export interface ITodoItemProps {
    todo: ITodo
}

const TodoItem = observer(({ todo }: ITodoItemProps) => {
    const onRenameTodo = (e: React.ChangeEvent<HTMLInputElement>) => {
        todo.title = e.target.value;
    }

    return (
        <div key={todo.id} className="todoItem">
            <div className="todoItem-body">
                <div className="todoItem-title">
                    <input type="text" value={todo.title} onChange={onRenameTodo} />
                </div>
                {/* <div className="todoItem-description">{todo.description}</div> */}

            </div>
            <div className={todo.isDone ? "todoItem-indicator done" : "todoItem-indicator"} onClick={() => todo.isDone = !todo.isDone}>

            </div>
        </div>
    );
});

export default TodoItem;
