import React, { FC } from 'react';
import "./modal.css";

export interface IModalProps {
    isVisible: boolean,
    setVisible: (isVisible: boolean) => void,
    children: React.ReactElement
}

export default function Modal(props: IModalProps) {
    return (
        <div className={props.isVisible ? "modal active" : "modal"} onClick={() => props.setVisible(false)}>
            <div className="modal__content" onClick={e => e.stopPropagation()}>
                {props.children}
            </div>
        </div>
    );
}
