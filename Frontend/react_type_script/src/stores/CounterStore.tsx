import { makeAutoObservable, makeObservable } from "mobx";

interface ICounter {
    count: number
}

class CounterStore implements ICounter {
    count = 0;

    constructor() {
        makeAutoObservable(this);
    }

    increment() {
        this.count = this.count + 1;
    }

    decrement() {
        this.count = this.count - 1;
    }

}

export default new CounterStore();
