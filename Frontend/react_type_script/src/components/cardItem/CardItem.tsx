import * as React from 'react';
import { ITodo } from '../../types/types';
import { observer } from 'mobx-react';

export interface ICardProps {
    todo: ITodo
}

const CardItem = observer((props: ICardProps) => {
    return (
        <div key={props.todo.id}>
            <div>{props.todo.title}</div>
            <div>{props.todo.desciption}</div>
            <div>{props.todo.endedAt.toISOString()}</div>
            <div>{props.todo.isDone ? "Да" : "Нет"}</div>
        </div>
    );
});

export default CardItem;
