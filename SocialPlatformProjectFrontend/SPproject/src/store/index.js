import { createStore } from 'vuex'

const store = createStore({
    state: {
        Category: [
            {
                Id: 1,
                Title: 'Computer',
                Description: 'Bla bla bla Computers',
            },
            {
                Id: 2,
                Title: 'Fishing',
                Description: 'Bla bla bla Fishing',
            },
            {
                Id: 3,
                Title: 'Studies',
                Description: 'Bla bla bla Studies',
            },
        ],

        Thread: [
            {
                Id: 1,
                Title: 'Will computers take over the world?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 1,
            },
            {
                Id: 2,
                Title: 'Will computers NOT take over the world?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 1,
            },
            {
                Id: 3,
                Title: 'Will Mike ever NOT discuss things?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 3,
            },
            {
                Id: 4,
                Title: 'How good is Newton?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 3,
            },
            {
                Id: 5,
                Title: 'I swear look at this fish?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 2,
            },
            {
                Id: 6,
                Title: 'Do studies make you depressed?',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 3,
            },
            {
                Id: 7,
                Title: 'STUDIES MAKE YOU RICH INVEST EVERYTHING',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 3,
            },
            {
                Id: 8,
                Title: 'Super computer 30000',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 1,
            },
            {
                Id: 9,
                Title: 'BIG FISH THREAD',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 2,
            },
            {
                Id: 10,
                Title: 'WALLE - E MIKE EDITION',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 1,
            },
            {
                Id: 11,
                Title: 'MIKES FISH IS AMAZING MICROTRANSISTIONS',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 2,
            },
            {
                Id: 12,
                Title: 'Study more, earn less',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 3,
            },
            {
                Id: 13,
                Title: 'Fish Fish Fish',
                Text: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.',
                CategoryId: 2,
            },
        ],

        reply: [
            {
                Id: 1,
                Text: 'reply to thread id 2',
                CreatedDate: '2022-01-01',
                UserId: 22,
                ThreadId: 2,
            },
            {
                Id: 2,
                Text: 'reply to thread id 1',
                CreatedDate: '2022-01-01',
                UserId: 22,
                ThreadId: 1,
            },
            {
                Id: 1,
                Text: 'reply to thread id 3',
                CreatedDate: '2022-01-01',
                UserId: 22,
                ThreadId: 3,
            },
            {
                Id: 1,
                Text: 'reply to thread id 4',
                CreatedDate: '2022-01-01',
                UserId: 22,
                ThreadId: 4,
            },
            {
                Id: 1,
                Text: 'reply to thread id 5',
                CreatedDate: '2022-01-01',
                UserId: 22,
                ThreadId: 5,
            },
            {
                Id: 1,
                Text: 'reply to thread id 6',
                CreatedDate: '2022-01-01',
                UserId: 22,
                ThreadId: 6,
            },
            {
                Id: 1,
                Text: 'reply to thread id 7',
                CreatedDate: '2022-01-01',
                UserId: 22,
                ThreadId: 7,
            },
            {
                Id: 1,
                Text: 'reply to thread id 8',
                CreatedDate: '2022-01-01',
                UserId: 22,
                ThreadId: 8,
            },
            {
                Id: 1,
                Text: 'reply to thread id 9',
                CreatedDate: '2022-01-01',
                UserId: 22,
                ThreadId: 9,
            },
            {
                Id: 1,
                Text: 'reply to thread id 10',
                CreatedDate: '2022-01-01',
                UserId: 22,
                ThreadId: 10,
            },
        ],
    },
    mutations: {
        setReply(state, value) {
            state.reply = value
        },
        setNewPost(state, data){
            console.log('inne i setNewPostMutatuon: ', data);
            state.Thread.push(data);
            console.log(state.Thread);
        },
    },
    actions: {

        createNewPostMethod({commit}, newPostObject){
            console.log('Inne i createNewPostMethod action: ', newPostObject)

            commit('setNewPost', newPostObject);
        }

    },

})

export default store
