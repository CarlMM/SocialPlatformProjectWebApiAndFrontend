<template>
    <div>
        <h1>POST YO</h1>
    </div>
    <div v-for="thread in getSpecificThread" :key="thread.Id">
        {{ thread.Title }}

        <div class="subforum-description subforum-column">
            <div v-for="reply in getReplies" :key="reply.Id">
                {{ reply.Text }}
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            tId: this.$route.params.Id,
        }
    },

    computed: {
        getSpecificThread() {
            let list = this.$store.state.Thread
            console.log(this.tId)

            let filteredThread = list.filter(item => {
                return item.Id == this.tId
            })
            console.log(filteredThread)
            return filteredThread
        },
        getReplies() {
            let replyList = this.$store.state.reply
            console.log(replyList)
            console.log(this.tId, 'THREAD ID!!!!!')
            let filterReplylist = replyList.filter(item => {
                console.log(item.ThreadId)
                return item.ThreadId == this.tId
            })
            console.log(filterReplylist)
            return filterReplylist
        },
    },
}
</script>
