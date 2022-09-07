import { makeAutoObservable } from "mobx";
import { ITodo } from "../types/types";

export class TodoStore implements ITodo {
    id: string = "";
    title: string = "";
    isDone: boolean = false;
    description: string = "";

    constructor() {
        makeAutoObservable(this);
    }

    toggle() {
        this.isDone = !this.isDone;
    }

    setTitle(title: string) {
        this.title = title;
    }

    setDescription(description: string) {
        this.description = description;
    }
}
