import { PrettyChatWindow } from 'react-chat-engine-pretty';

const ChatsPage = (props) => {
    const customStyles = {
        chatContainer: {
            backgroundColor: 'white', // Background color of the chat window
        },
        messageContainer: {
            user: {
                backgroundColor: 'lightblue', // Background color for user messages
            },
            agent: {
                backgroundColor: 'blue', // Background color for agent (bot) messages
            },
        },
    };

    return (
        <div style={{ height: '100vh' }}>
            <PrettyChatWindow
                projectId='9ccb6c0d-1020-42f8-b37c-d4f00887b713'
                username={props.user.username}
                secret={props.user.secret}
                styles={customStyles}
                style={{ height: '100%' }}
            />
        </div>
    );
}

export default ChatsPage;
