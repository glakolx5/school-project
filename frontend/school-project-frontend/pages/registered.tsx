import React from 'react'
import Link from 'next/link' 

function registered() {
    return (
        <>
            <div className='py-32 px-32 text-3xl'>
                Thanks for registering!
            </div>

            <Link href={'/'}>Go back to home</Link>
        </>
    )
}

export default registered