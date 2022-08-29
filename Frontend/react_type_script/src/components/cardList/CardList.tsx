import * as React from 'react';
import { ITodo } from '../../types/types';
import CardItem from '../cardItem/CardItem';
import { observer } from 'mobx-react';

export interface ICardListProps {
    todos: ITodo[]
}

const CardList = observer((props: ICardListProps) => {
    return (
        <div>
            {props.todos.map(todo =>
                <CardItem todo={todo} key={todo.id} />
            )}
        </div>
    );
});

export default CardList;
