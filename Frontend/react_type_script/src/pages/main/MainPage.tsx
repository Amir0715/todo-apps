import * as React from 'react';
import { CardList } from '../../components/cardList/CardList';
import Counter from '../../components/counter/counter';
import "./MainPage.css";

export interface IMainPageProps {
}

export default function MainPage(props: IMainPageProps) {
    React.useEffect(() => {

    }, [])

    return (
        <div>
            <div className="centered">
                <CardList />
            </div>
        </div>
    );
}
