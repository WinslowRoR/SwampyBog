/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID SWAMPYBOG_PAUSE_MUSIC = 2356596639U;
        static const AkUniqueID SWAMPYBOG_PLAY_MUSIC_SYSTEM = 937343755U;
        static const AkUniqueID SWAMPYBOG_UNPAUSE_MUSIC = 781157024U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace BOSSSTATUS
        {
            static const AkUniqueID GROUP = 549431000U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace BOSSSTATUS

        namespace MUSIC_SYSTEM
        {
            static const AkUniqueID GROUP = 792781730U;

            namespace STATE
            {
                static const AkUniqueID BOSSFIGHT = 580146960U;
                static const AkUniqueID GAMEPLAY = 89505537U;
                static const AkUniqueID MENU = 2607556080U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID SECRETLEVEL = 778026301U;
            } // namespace STATE
        } // namespace MUSIC_SYSTEM

        namespace SWAMPYBOG_GAMEPLAYSONGCHOICE
        {
            static const AkUniqueID GROUP = 1654822869U;

            namespace STATE
            {
                static const AkUniqueID MINOTAUR = 2719492022U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID SCARLETDRIZZLE = 97421041U;
            } // namespace STATE
        } // namespace SWAMPYBOG_GAMEPLAYSONGCHOICE

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID PLAYERHEALTH = 151362964U;
        static const AkUniqueID TELEPORTERPLAYERSTATUS = 1010989040U;
        static const AkUniqueID VOLUME_MASTER = 3695994288U;
        static const AkUniqueID VOLUME_MSX = 3729143042U;
        static const AkUniqueID VOLUME_SFX = 3673881719U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID SWAMPYBOGMUSIC = 186958281U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
