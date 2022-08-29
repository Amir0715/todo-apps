import { observer } from 'mobx-react';
import * as React from 'react';
import counter from "../../stores/CounterStore";

export interface ICounterProps {

}

const Counter = observer((props: ICounterProps) => {
    return (
        <div>
            <div>{"Count: " + counter.count}</div>
            <button onClick={() => counter.increment()}>+</button>
            <button onClick={() => counter.decrement()}>-</button>
        </div>
    );
})

export default Counter;
