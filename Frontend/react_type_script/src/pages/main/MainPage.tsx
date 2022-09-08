import React, { useState, useEffect } from 'react';
import TodoList from '../../components/TodoList/TodoList';
import Modal from '../../components/Modal/Modal';
import RootStore from '../../stores/RootStore';
import "./MainPage.css";
import AddForm, { FormData } from '../../components/AddForm/AddForm';
import { Todo } from '../../stores/Todo';
import { observer } from 'mobx-react';

export interface IMainPageProps {
}

const MainPage = (props: IMainPageProps) => {
    const [modalVisible, setModalVisible] = useState<boolean>(false);

    useEffect(() => {
        RootStore.todosStore.fetchTodos();
    }, [])

    const onAdd = (data: FormData) => {
        let todo = new Todo(data.title, data.description, data.done);
        RootStore.todosStore.add(todo);
        setModalVisible(false);
    }

    return (
        <div className="section">
            <div className="centered">
                <TodoList todos={RootStore.todosStore.todos} />
            </div>
            <div className="centered">
                <button onClick={() => setModalVisible(true)}>Add</button>
            </div>
            <Modal isVisible={modalVisible} setVisible={setModalVisible}>
                <AddForm onSubmit={onAdd} />
            </Modal>
        </div>
    );
};

export default observer(MainPage);
