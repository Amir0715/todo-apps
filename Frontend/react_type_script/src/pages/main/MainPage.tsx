import React, { useState } from 'react';
import TodoList from '../../components/TodoList/TodoList';
import Modal from '../../components/Modal/Modal';
import Store from '../../stores/Store';
import "./MainPage.css";
import AddForm from '../../components/AddForm/AddForm';

export interface IMainPageProps {
}

export default function MainPage(props: IMainPageProps) {
    const [modalVisible, setModalVisible] = useState<boolean>(false);

    return (
        <div className="section">
            <div className="centered">
                <TodoList todos={Store.todosStore.todos} />
            </div>
            <div className="centered">
                <button onClick={() => setModalVisible(true)} >Add</button>
            </div>
            <Modal isVisible={modalVisible} setVisible={setModalVisible}>
                <AddForm />
            </Modal>
        </div>
    );
}
