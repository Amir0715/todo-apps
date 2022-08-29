export interface ITodo {
    id: string,
    title: string,
    desciption: string,
    endedAt: Date,
    isDone: boolean
}

export class Todo implements ITodo {
    id: string = "";
    title: string = "";
    desciption: string = "";
    isDone: boolean = false;
    endedAt: Date = new Date();
}
