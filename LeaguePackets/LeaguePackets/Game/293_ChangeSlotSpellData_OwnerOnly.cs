﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.Game.Common;

namespace LeaguePackets.Game
{
    public class ChangeSlotSpellData_OwnerOnly : GamePacket // 0x125
    {
        public override GamePacketID ID => GamePacketID.ChangeSlotSpellData_OwnerOnly;
        public ChangeSpellData ChangeSpellData { get; set; } = null;

        protected override void ReadBody(ByteReader reader)
        {

            this.ChangeSpellData = reader.ReadChangeSpellData();
        }
        protected override void WriteBody(ByteWriter writer)
        {
            writer.WriteChangeSpellData(ChangeSpellData);
        }
    }
}
