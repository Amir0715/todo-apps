import * as React from 'react';
import { observer } from 'mobx-react';
import "./todoItem.css";
import { Todo } from '../../stores/Todo';

export interface ITodoItemProps {
    todo: Todo
}

const TodoItem = observer(({ todo }: ITodoItemProps) => {
    const onRenameTodo = (e: React.ChangeEvent<HTMLInputElement>) => {
        todo.setTitle(e.target.value);
    }

    return (
        <div key={todo.id} className="todoItem">
            <div className="todoItem-body">
                <div className="todoItem-title">
                    <input type="text" value={todo.title} onChange={onRenameTodo} />
                </div>
                {/* <div className="todoItem-description">{todo.description}</div> */}

            </div>
            <div className={todo.isDone ? "todoItem-indicator done" : "todoItem-indicator"} onClick={() => todo.toggle()}>

            </div>
        </div>
    );
});

export default TodoItem;
