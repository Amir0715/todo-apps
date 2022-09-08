import { v4 as uuidv4 } from 'uuid';
import { makeAutoObservable } from "mobx";
import { ITodo } from "../types/types";

export class Todo implements ITodo {
    id: string;
    title: string;
    isDone: boolean;
    description: string;

    constructor(title: string, description: string, isDone: boolean) {
        this.id = uuidv4();
        this.isDone = isDone;
        this.title = title;
        this.description = description;
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
